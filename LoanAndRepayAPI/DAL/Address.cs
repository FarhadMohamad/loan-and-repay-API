//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoanAndRepayAPI.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Address
    {
        public int Id { get; set; }
        public Nullable<int> InstallmentId { get; set; }
        public string UserId { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string CityName { get; set; }
        public Nullable<int> PostCode { get; set; }
    
        public virtual CompanyInfo CompanyInfo { get; set; }
        public virtual InstallmentRequest InstallmentRequest { get; set; }
    }
}
