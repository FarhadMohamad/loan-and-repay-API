using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanAndRepayAPI.Models;
using LoanAndRepayAPI.DAL;

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

            // string currentUserId = User.Identity.GetUserId();

            LoanAndRepayEntities loanAndRepayEntities = new LoanAndRepayEntities();
                                        


            using (loanAndRepayEntities)
            {
                installmentRequest = (from companyInfo in loanAndRepayEntities.CompanyInfoes
                                      join companyInfoJoin in loanAndRepayEntities.InstallmentRequests on companyInfo.CompanyName equals companyInfoJoin.Company

                                      where companyInfo.Email == email


                                      select new InstallmentRequestViewModel()
                                      {

                                          Company = companyInfoJoin.Company,
                                          FirstName = companyInfoJoin.FirstName,
                                          LastName = companyInfoJoin.LastName,
                                          Email = companyInfoJoin.Email

                                     }).Distinct().ToList();
            }

            if (installmentRequest.Count == 0)
            {
                return NotFound();
            }
            return Ok(installmentRequest);
        }

    }
}
