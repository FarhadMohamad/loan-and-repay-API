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
        [Authorize]
        [Route("api/InstallmentRequest")]
        public IHttpActionResult InstallmentRequest(InstallmentRequestViewModel model)
        {


            string currentUserId = User.Identity.GetUserId();



            LoanAndRepayEntities loanAndRepayEntities = new LoanAndRepayEntities();

            //Request r = new Request();



            var findUserId = loanAndRepayEntities.AspNetUsers.Where(x => x.Id == currentUserId).SingleOrDefault();
            //if (req != null)
            //{
            ClientProvider.SaveInstallmentRequest(model, findUserId.Id);
            EmailService.sendEmailToCompany(model);


            //}

            return Ok();

        }

        //[Authorize]
        [Route("api/InstallmentRequestStatus")]
        public IHttpActionResult InstallmentRequestStatus()
        {

            IList<InstallmentRequestStatusViewModel> installmentRequest = null;

            //string currentUserId = User.Identity.GetUserId();

            LoanAndRepayEntities loanAndRepayEntities = new LoanAndRepayEntities();

            

            var database = new LoanAndRepayEntities();
           

            using (database)
            {
                installmentRequest = (from installment in database.InstallmentRequests
                                      //where installment.UserId == currentUserId

                                      
                                      select new InstallmentRequestStatusViewModel()
                                      {
                                        
                                          Company = installment.Company,
                                          Status = installment.Status


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
