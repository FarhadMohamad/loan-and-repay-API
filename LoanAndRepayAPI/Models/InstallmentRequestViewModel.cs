using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanAndRepayAPI.Models
{
    public class InstallmentRequestViewModel: Address
    {
        public string UserId { get; set; }
        public string Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public string Phone { get; set; }     
        public decimal? Amount { get; set; }
        public string PayWithIn { get; set; }
        public decimal? MonthlyPayment { get; set; }
        public int? Status { get; set; } = 0;
    }

  
}