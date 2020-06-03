﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoanAndRepayAPI.Models;
using LoanAndRepayAPI.DAL;

namespace LoanAndRepayAPI.Providers
{
    public class ClientProvider
    {
        public static void  CreateUser(RegisterBindingModel registerBindingModel)
        {

            LoanAndRepayEntities entities = new LoanAndRepayEntities();
            AspNetUser user = entities.AspNetUsers.SingleOrDefault(x => x.Email == registerBindingModel.Email);

            if (user != null)
            {
                user.FirstName = registerBindingModel.FirstName;
                user.LastName = registerBindingModel.LastName;
                user.PhoneNumber = registerBindingModel.PhoneNumber;
                user.Email = registerBindingModel.Email;
                
                entities.SaveChanges();
            }            

        }

        public static void SaveInstallmentRequest(InstallmentRequestViewModel model, string UserId)
        {

            LoanAndRepayEntities entities = new LoanAndRepayEntities();
            InstallmentRequest installmentRequest = new InstallmentRequest();
            DAL.Address address = new DAL.Address();

            //First saves the installment request information in the installment table
            installmentRequest.UserId = UserId;
            installmentRequest.Company = model.Company;
            installmentRequest.FirstName = model.FirstName;
            installmentRequest.LastName = model.LastName;
            installmentRequest.Email = model.Email;
            installmentRequest.Age = model.Age;
            installmentRequest.Phone = model.Phone;         
            installmentRequest.Amount = model.Amount;
            installmentRequest.PayWithIn = model.PayWithIn;
            installmentRequest.MonthlyPayment = model.MonthlyPayment;
            installmentRequest.Status = model.Status;
            entities.InstallmentRequests.Add(installmentRequest);
            entities.SaveChanges();

            //Then saves the installment request address in the address table
            address.StreetName = model.StreetName;
            address.HouseNumber = model.HouseNumber;
            address.CityName = model.CityName;
            address.PostCode = model.PostCode;

            var findInstallmentRequestId = entities.InstallmentRequests.Where(x => x.Company== model.Company && x.Email == model.Email && x.Status == 0).SingleOrDefault();
            address.InstallmentId = findInstallmentRequestId.Id;
            entities.Addresses.Add(address);
            entities.SaveChanges();

        }
    }
}