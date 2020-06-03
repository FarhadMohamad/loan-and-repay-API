using LoanAndRepayAPI.DAL;
using LoanAndRepayAPI.Models;

namespace LoanAndRepayAPI.Providers
{
    public class CompanyProvider
    {

        public static void SaveCompanyInfo(RegisterCompanyBindingModel registerCompanyModel, string userId)
        {

            LoanAndRepayEntities database = new LoanAndRepayEntities();

            CompanyInfo companyInfo = new CompanyInfo();
            DAL.Address address = new DAL.Address();
            if (companyInfo != null)
            {
                //First saves the company information in the company table
                companyInfo.UserId = userId;
                companyInfo.CompanyName = registerCompanyModel.CompanyName;
                companyInfo.CVR = registerCompanyModel.CVR;
                companyInfo.Email = registerCompanyModel.Email;
                companyInfo.Phone = registerCompanyModel.Phone;
                database.CompanyInfoes.Add(companyInfo);

                //Then saves the company address in the address table
                address.StreetName = registerCompanyModel.StreetName;
                address.HouseNumber = registerCompanyModel.HouseNumber;
                address.CityName = registerCompanyModel.CityName;
                address.PostCode = registerCompanyModel.PostCode;
                address.UserId = userId;
                database.Addresses.Add(address);
                database.SaveChanges();

           }

        }


    }
}