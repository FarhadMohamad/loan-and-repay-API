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
    
    public partial class CompanyInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompanyInfo()
        {
            this.Addresses = new HashSet<Address>();
        }
    
        public string UserId { get; set; }
        public string CompanyName { get; set; }
        public Nullable<int> CVR { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
