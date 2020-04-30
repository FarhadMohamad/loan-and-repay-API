using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoanAndRepayAPI.Models;
using LoanAndRepayAPI.DAL;

namespace LoanAndRepayAPI.Providers
{
    public class ClientProvider
    {
        public static void CreateUser(RegisterBindingModel registerBindingModel)
        {

            LoanAndRepayEntities db = new LoanAndRepayEntities();

            AspNetUser user = db.AspNetUsers.SingleOrDefault(x => x.Email == registerBindingModel.Email);

            if (user != null)
            {
                user.FirstName = registerBindingModel.FirstName;
                user.LastName = registerBindingModel.LastName;
                user.PhoneNumber = registerBindingModel.PhoneNumber;
                user.Email = registerBindingModel.Email;

                db.SaveChanges();
            }


        }

        public static void SaveInstallmentRequest(InstallmentRequestViewModel model, string UserId)
        {

            LoanAndRepayEntities loanAndRepayEntities = new LoanAndRepayEntities();
            InstallmentRequest paymentRequest = new InstallmentRequest();
            // var user = loanAndRepayEntities.AspNetUsers.Where(x => x.Email == model.Email).SingleOrDefault();

            //if (user != null)
            //{
            paymentRequest.UserId = UserId;
            paymentRequest.Company = model.Company;
            paymentRequest.FirstName = model.FirstName;
            paymentRequest.LastName = model.LastName;
            paymentRequest.Email = model.Email;
            paymentRequest.Age = model.Age;
            paymentRequest.Phone = model.Phone;
            paymentRequest.StreetName = model.StreetName;
            paymentRequest.HouseNumber = model.HouseNumber;
            paymentRequest.CityName = model.CityName;
            paymentRequest.PostCode = model.PostCode;
            paymentRequest.Amount = model.Amount;
            paymentRequest.PayWithIn = model.PayWithIn;
            paymentRequest.MonthlyPayment = model.MonthlyPayment;
            paymentRequest.Status = model.Status;
            loanAndRepayEntities.InstallmentRequests.Add(paymentRequest);
            loanAndRepayEntities.SaveChanges();
            //}


        }
    }
}