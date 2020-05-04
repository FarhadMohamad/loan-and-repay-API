using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanAndRepayAPI.Models;
using LoanAndRepayAPI.DAL;
using Microsoft.AspNet.Identity;
using LoanAndRepayAPI.Providers;

namespace LoanAndRepayAPI.Controllers
{
    public class CompanyController : ApiController
    {
        //[Authorize]        
        [HttpGet]
        [Route("api/GetRequestList")]
        public IHttpActionResult GetRequestList(string email)
        {

            IList<InstallmentRequestViewModel> installmentRequest = null;

            //string currentUserId = User.Identity.GetUserId();

            LoanAndRepayEntities loanAndRepayEntities = new LoanAndRepayEntities();



            using (loanAndRepayEntities)
            {
                installmentRequest = (from companyInfo in loanAndRepayEntities.CompanyInfoes
                                      join companyInfoJoin in loanAndRepayEntities.InstallmentRequests on companyInfo.CompanyName equals companyInfoJoin.Company

                                      where companyInfo.Email == email


                                      select new InstallmentRequestViewModel()
                                      {
                                          Id = companyInfoJoin.Id,
                                          Company = companyInfoJoin.Company,
                                          FirstName = companyInfoJoin.FirstName,
                                          LastName = companyInfoJoin.LastName,
                                          Email = companyInfoJoin.Email,
                                          Age = companyInfoJoin.Age,
                                          Phone = companyInfoJoin.Phone,
                                          StreetName = companyInfoJoin.StreetName,
                                          HouseNumber = companyInfoJoin.HouseNumber,
                                          CityName = companyInfoJoin.CityName,
                                          PostCode = companyInfoJoin.PostCode,
                                          Amount = companyInfoJoin.Amount,
                                          PayWithIn = companyInfoJoin.PayWithIn,
                                          MonthlyPayment = companyInfoJoin.MonthlyPayment,
                                          Status = companyInfoJoin.Status



                                      }).Distinct().ToList();
            }

            if (installmentRequest.Count == 0)
            {
                return NotFound();
            }
            return Ok(installmentRequest);
        }


        //[Authorize]        
        [HttpGet]
        [Route("api/SearchRequestByName")]
        public IHttpActionResult SearchRequestByName(string name, string email)
        {

            IList<InstallmentRequestViewModel> installmentRequest = null;

            //string currentUserId = User.Identity.GetUserId();

            LoanAndRepayEntities loanAndRepayEntities = new LoanAndRepayEntities();
                       
            using (loanAndRepayEntities)
            {
                installmentRequest = (from companyInfo in loanAndRepayEntities.CompanyInfoes
                                      join companyInfoJoin in loanAndRepayEntities.InstallmentRequests on companyInfo.CompanyName equals companyInfoJoin.Company

                                      where companyInfo.Email == email


                                      select new InstallmentRequestViewModel()
                                      {
                                          Id = companyInfoJoin.Id,
                                          Company = companyInfoJoin.Company,
                                          FirstName = companyInfoJoin.FirstName,
                                          LastName = companyInfoJoin.LastName,
                                          Email = companyInfoJoin.Email,
                                          Age = companyInfoJoin.Age,
                                          Phone = companyInfoJoin.Phone,
                                          StreetName = companyInfoJoin.StreetName,
                                          HouseNumber = companyInfoJoin.HouseNumber,
                                          CityName = companyInfoJoin.CityName,
                                          PostCode = companyInfoJoin.PostCode,
                                          Amount = companyInfoJoin.Amount,
                                          PayWithIn = companyInfoJoin.PayWithIn,
                                          MonthlyPayment = companyInfoJoin.MonthlyPayment,
                                          Status = companyInfoJoin.Status



                                      }).Distinct().ToList();
            }

            if (!string.IsNullOrEmpty(name))
            {
                installmentRequest = installmentRequest.Where(x => x.FirstName.ToLower().Contains(name.Trim())).ToList();
            }
            return Ok(installmentRequest);
        }

        [Authorize]
        [HttpPost]
        [Route("api/InstallmentRequestStatus")]
        public IHttpActionResult InstallmentRequestStatusUpdate(int id, int status)
        {

            string currentUserId = User.Identity.GetUserId();

            using (var entites = new LoanAndRepayEntities())
            {
                var req = entites.InstallmentRequests.Where(x => x.Id == id).SingleOrDefault();

                if (status == 1 && req != null)
                {
                    req.Status = status;
                    entites.SaveChanges();
                   
                }
                else if (status == 2 && req != null)
                {
                    req.Status = status;
                    entites.SaveChanges();

                }
            }


            return Ok();
        }

    }
}
