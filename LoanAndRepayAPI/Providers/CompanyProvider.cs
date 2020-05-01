using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoanAndRepayAPI.DAL;
using LoanAndRepayAPI.Models;

namespace LoanAndRepayAPI.Providers
{
    public class CompanyProvider
    {

        public static void CreateUser(RegisterCompanyBindingModel registerCompanyModel, string userId)
        {

            LoanAndRepayEntities database = new LoanAndRepayEntities();

            //AspNetUser user = db.AspNetUsers.SingleOrDefault(x => x.Email == registerCompanyModel.Email);
            CompanyInfo companyInfo = new CompanyInfo();
            if (companyInfo != null)
            {

                companyInfo.UserId = userId;
                companyInfo.CompanyName = registerCompanyModel.CompanyName;
                companyInfo.CVR = registerCompanyModel.CVR;
                companyInfo.Email = registerCompanyModel.Email;
                companyInfo.Website = registerCompanyModel.Website;
                companyInfo.Phone = registerCompanyModel.Phone;
                companyInfo.ContactPerson = registerCompanyModel.ContactPerson;
                companyInfo.StreetName = registerCompanyModel.StreetName;
                companyInfo.HouseNumber = registerCompanyModel.HouseNumber;
                companyInfo.CityName = registerCompanyModel.CityName;
                companyInfo.PostCode = registerCompanyModel.PostCode;
                database.CompanyInfoes.Add(companyInfo);
                database.SaveChanges();
            }


        }
    }
}