using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanAndRepayAPI.Models
{
    public class Address
    {

        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string CityName { get; set; }
        public Nullable<int> PostCode { get; set; }
    }
}