using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using LoanAndRepayAPI.Models;
using LoanAndRepayAPI.DAL;
namespace LoanAndRepayAPI.Services
{
    public class EmailService
    {

        public static string SendEmailToCompany(InstallmentRequestViewModel model)
        {
            LoanAndRepayEntities entities = new LoanAndRepayEntities();
            var findEmail = entities.CompanyInfoes.Where(x => x.CompanyName == model.Company).FirstOrDefault();
            
            try
            {

                SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                var mail = new System.Net.Mail.MailMessage();
                mail.From = new MailAddress("mitbud@outlook.com");
                mail.To.Add(findEmail.Email);
                mail.Subject = "Installment request for " + model.Company;
                mail.IsBodyHtml = true;
                string htmlBody;

                htmlBody = "Hi " + model.Company + "," + "<br />" + "<br />"
                    + "The following person requests for an installement:" + "<br />" + "<br />"
                    + "First Name = " + model.FirstName  + "<br />"
                   + "Last Name = " + model.LastName  + "<br />"
                   + "Email = " + model.Email + "<br />"
                   + "Age = " + model.Age + "<br />"
                    + "Phone = " + model.Phone + "<br />"
                   + "Street Name = " + model.StreetName + "<br />"
                    + "House Number = " + model.HouseNumber + "<br />"
                     + "City Name = " + model.CityName + "<br />"
                      + "Post Code = " + model.PostCode + "<br />"
                      + "Amount = " + model.Amount + "<br />"
                   + "Pay within = " + model.PayWithIn + "<br />" + "<br />"
                   + "Regards," + "<br />"
                + "SteamFoss" + ".";
                mail.Body = htmlBody;
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new NetworkCredential("mitbud@outlook.com", "m42929264.", "Outlook.com");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

                return "sent";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
    }
}