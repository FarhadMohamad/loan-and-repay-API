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
    }
}