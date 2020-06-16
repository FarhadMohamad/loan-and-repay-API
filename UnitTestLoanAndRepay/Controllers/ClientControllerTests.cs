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
        public void StatusPendingPassTest()
        {
            //Arrange
            InstallmentRequestStatusViewModel installment = new InstallmentRequestStatusViewModel()
            {
                Company = "Driving Licence",
                Status = "Pending"
            };
            var controller = new ClientController();
            //Act
            var actionResult = controller.StatusPending("a@a.com");
            var response = actionResult as OkNegotiatedContentResult<List<InstallmentRequestStatusViewModel>>;
            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(installment.Status, response.Content[1].Status);
            Assert.AreEqual(installment.Company, response.Content[1].Company);
        }



        [TestMethod]
        public void InstallmentRequestPassTest()
        {
            // Arrange  
            var controller = new ClientController();
            //Act
            var actionResult = controller.InstallmentRequest(new InstallmentRequestViewModel
            {
                UserId = "e803b255-c968-4952-89ca-83e10e62dd2a",
                Company = "Alliance Trafikskole",
                FirstName = "Farhad",
                LastName = "Janus",
                Email = "farhad@hotmail.dk",
                Age = 30,
                Phone = "42221047",
                StreetName = "Gravenstensvej",
                HouseNumber = "8",
                CityName = "Sorø",
                PostCode = 4180,
                Amount = 1000,
                PayWithIn = "6 months",
                //MonthlyPayment = 191.67
            });
            //Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        //[TestMethod()]
        //public void StatusAcceptedTest()
        //{
        //    //Arrange
        //    InstallmentRequestStatusViewModel installment = new InstallmentRequestStatusViewModel()
        //    {
        //        Company = "Driving Licence",
        //        Status = "Accepted"

        //    };

        //    var controller = new ClientController();

        //    //Act
        //    var actionResult = controller.StatusAccepted("string@shit.com");
        //    var response = actionResult as OkNegotiatedContentResult<List<InstallmentRequestStatusViewModel>>;

        //    //Assert
        //    Assert.IsNotNull(response);

        //    Assert.AreEqual(installment.Status, response.Content[0].Status);
        //    Assert.AreEqual(installment.Company, response.Content[0].Company);
        //}
    }
}