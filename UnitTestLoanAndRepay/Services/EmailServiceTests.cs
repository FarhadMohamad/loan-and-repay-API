﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoanAndRepayAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanAndRepayAPI.Models;

namespace LoanAndRepayAPI.Services.Tests
{
    [TestClass()]
    public class EmailServiceTests
    {
        [TestMethod()]
        public void sendEmailToCompanyPassTest()
        {

            InstallmentRequestViewModel installmentRequestViewModel = new InstallmentRequestViewModel
            {

                Company = "Alliance Trafikskole",
                FirstName = "for the email",
                LastName = "Atmar",
                Email = "art_ismat@hotmail.com",
                Age = 12,
                Phone = "234324",
                StreetName = "asdfasd",
                HouseNumber = "sadfasdf",
                CityName = "asdf",
                PostCode = 333,
                Amount = 123,
                PayWithIn = "6 months",
                MonthlyPayment = 2342

            };

            //Assert.IsNotNull(installmentRequestViewModel.Company);


            Assert.AreEqual("sent", EmailService.SendEmailToCompany(installmentRequestViewModel));

        }

        [TestMethod()]
        public void sendEmailToCompanyFailTest()
        {

            InstallmentRequestViewModel installmentRequestViewModel = new InstallmentRequestViewModel
            {

                //Company = "Alliance Trafikskole",
                FirstName = "for the email",
                LastName = "Atmar",
                //Email = "art_ismat@hotmail.com",
                Age = 12,
                Phone = "234324",
                StreetName = "asdfasd",
                HouseNumber = "sadfasdf",
                CityName = "asdf",
                PostCode = 333,
                Amount = 123,
                PayWithIn = "6 months",
                MonthlyPayment = 2342


            };

            Assert.IsNull(installmentRequestViewModel.Company);
            Assert.IsNull(installmentRequestViewModel.Email);


            //Assert.AreEqual("sent", EmailService.SendEmailToCompany(installmentRequestViewModel));

        }
    }
}
