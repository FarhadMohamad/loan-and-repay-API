using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanAndRepayAPI.Models;
using Microsoft.AspNet.Identity;
using LoanAndRepayAPI.DAL;
using LoanAndRepayAPI.Providers;
using LoanAndRepayAPI.Services;

namespace LoanAndRepayAPI.Controllers
{
    public class ClientController : ApiController
    {
        //[Authorize]
        [Route("api/InstallmentRequest")]
        public IHttpActionResult InstallmentRequest(InstallmentRequestViewModel model)
        {

            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            //string currentUserId = User.Identity.GetUserId();
            string currentUserId = model.UserId;



            LoanAndRepayEntities loanAndRepayEntities = new LoanAndRepayEntities();

            //Request r = new Request();



           // var findUserId = loanAndRepayEntities.AspNetUsers.Where(x => x.Id == currentUserId).SingleOrDefault();
            //if (req != null)
            //{
            ClientProvider.SaveInstallmentRequest(model, currentUserId);
            EmailService.sendEmailToCompany(model);


            //}
        
            return Ok();

        }

       

       //[Authorize]
        [HttpGet]
        [Route("api/StatusPending")]
        public IHttpActionResult StatusPending(string email)
        {

            List<InstallmentRequestStatusViewModel> installmentRequest = null;

            //string currentUserId = User.Identity.GetUserId();

            LoanAndRepayEntities loanAndRepayEntities = new LoanAndRepayEntities();

            

            var database = new LoanAndRepayEntities();
           

            using (database)
            {
                installmentRequest = (from installment in database.InstallmentRequests
                                          where installment.Email == email && installment.Status == 0
                                     


                                      select new InstallmentRequestStatusViewModel()
                                      {

                                          Company = installment.Company,
                                          Status = "Pending",


                                      }).ToList<InstallmentRequestStatusViewModel>();
            }

            if (installmentRequest.Count == 0)
            {
                return NotFound();
            }
            return Ok(installmentRequest);
        }

        //[Authorize]
        [HttpGet]
        [Route("api/StatusAccepted")]
        public IHttpActionResult StatusAccepted(string email)
        {

            IList<InstallmentRequestStatusViewModel> installmentRequest = null;

           // string currentUserId = User.Identity.GetUserId();

            LoanAndRepayEntities loanAndRepayEntities = new LoanAndRepayEntities();



            var database = new LoanAndRepayEntities();


            using (database)
            {
                installmentRequest = (from installment in database.InstallmentRequests
                                     where installment.Email == email && installment.Status == 1
                                      //where installment.Status == 1

                                      select new InstallmentRequestStatusViewModel()
                                      {

                                          Company = installment.Company,
                                          Status = "Accepted",


                                      }).ToList<InstallmentRequestStatusViewModel>();
            }

            if (installmentRequest.Count == 0)
            {
                return NotFound();
            }
            return Ok(installmentRequest);
        }

        //[Authorize]
        [HttpGet]
        [Route("api/StatusRejected")]
        public IHttpActionResult StatusRejected(string email)
        {

            IList<InstallmentRequestStatusViewModel> installmentRequest = null;

            //string currentUserId = User.Identity.GetUserId();

            LoanAndRepayEntities loanAndRepayEntities = new LoanAndRepayEntities();



            var database = new LoanAndRepayEntities();


            using (database)
            {
                installmentRequest = (from installment in database.InstallmentRequests
                                      where installment.Email == email && installment.Status == 2
                                      //where installment.Status == 2

                                      select new InstallmentRequestStatusViewModel()
                                      {

                                          Company = installment.Company,
                                          Status = "Rejected"


                                      }).ToList<InstallmentRequestStatusViewModel>();
            }

            if (installmentRequest.Count == 0)
            {
                return NotFound();
            }
            return Ok(installmentRequest);
        }
    }
}
