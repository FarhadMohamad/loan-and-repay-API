using LoanAndRepayAPI.DAL;
using LoanAndRepayAPI.Models;
using LoanAndRepayAPI.Providers;
using LoanAndRepayAPI.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LoanAndRepayAPI.Controllers
{
    public class ClientController : ApiController
    {
        [Authorize(Roles = "Client")]
        [Route("api/InstallmentRequest")]
        public IHttpActionResult InstallmentRequest(InstallmentRequestViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            string currentUserId = User.Identity.GetUserId();

            try
            {
                ClientProvider.SaveInstallmentRequest(model, currentUserId);
                EmailService.sendEmailToCompany(model);
            }
            catch (Exception)
            {

                return NotFound();
            }

            return Ok();

        }

        //[Authorize]
        [HttpGet]
        [Route("api/StatusPending")]
        public IHttpActionResult StatusPending(string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            List<InstallmentRequestStatusViewModel> installmentRequest = null;

            //string currentUserId = User.Identity.GetUserId();

            LoanAndRepayEntities entities = new LoanAndRepayEntities();

            using (entities)
            {
                installmentRequest = (from installment in entities.InstallmentRequests
                                      where installment.Email == email && installment.Status == 0

                                      select new InstallmentRequestStatusViewModel()
                                      {

                                          Company = installment.Company,
                                          Status = "Pending",


                                      }).ToList();
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
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            IList<InstallmentRequestStatusViewModel> installmentRequest = null;

            // string currentUserId = User.Identity.GetUserId();

            LoanAndRepayEntities entities = new LoanAndRepayEntities();

            using (entities)
            {
                installmentRequest = (from installment in entities.InstallmentRequests
                                      where installment.Email == email && installment.Status == 1
                                      //where installment.Status == 1

                                      select new InstallmentRequestStatusViewModel()
                                      {

                                          Company = installment.Company,
                                          Status = "Accepted",

                                      }).ToList();
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
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            IList<InstallmentRequestStatusViewModel> installmentRequest = null;

            //string currentUserId = User.Identity.GetUserId();

            LoanAndRepayEntities entities = new LoanAndRepayEntities();

            using (entities)
            {
                installmentRequest = (from installment in entities.InstallmentRequests
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
