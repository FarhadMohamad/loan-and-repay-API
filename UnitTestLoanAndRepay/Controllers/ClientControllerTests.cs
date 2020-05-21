using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoanAndRepayAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;
using LoanAndRepayAPI.Models;
using LoanAndRepayAPI.DAL;
using LoanAndRepayAPI.Providers;
using LoanAndRepayAPI.Services;
using System.Web.Http.Results;
using System.Configuration;
using System.Net;

namespace LoanAndRepayAPI.Controllers.Tests
{
    [TestClass()]
    public class ClientControllerTests
    {

        [TestMethod]
        public void StatusPendingTest()

        {
            //Arrange
            InstallmentRequestStatusViewModel installment = new InstallmentRequestStatusViewModel()
            {
                Company = "Driving Licence",
                Status = "Pending"

            };

            var controller = new ClientController();

            //Act
            var actionResult = controller.StatusPending("string@shit.com");
            var response = actionResult as OkNegotiatedContentResult<List<InstallmentRequestStatusViewModel>>;

            //Assert
            Assert.IsNotNull(response);

            Assert.AreEqual(installment.Status, response.Content[0].Status);
            Assert.AreEqual(installment.Company, response.Content[0].Company);

        }



        [TestMethod]
        public void InstallmentRequestTest()
        {

            // Arrange  
            var controller = new ClientController();



            var actionResult = controller.InstallmentRequest(new InstallmentRequestViewModel
            {
                UserId = "e803b255-c968-4952-89ca-83e10e62dd2a",
                Company = "Driving Licence",
                FirstName = "we are testing it nowuff",
                LastName = "The author",
                Email = "asdfjl@a.com",
                Age = 12,
                Phone = "234324",
                StreetName = "asdfasd",
                HouseNumber = "sadfasdf",
                CityName = "asdf",
                PostCode = 333,
                Amount = 123,
                PayWithIn = "6 months",
                MonthlyPayment = 2342
            });

            Assert.IsNotNull(actionResult);


            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod()]
        public void StatusAcceptedTest()
        {
            Assert.Fail();
        }
    }
}