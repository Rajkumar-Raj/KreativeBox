//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CreativeBox.Data.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUniversity
    {
        public long UniversityId { get; set; }
        public string UniversityName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string PrimaryPhone { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string UniversityLogo { get; set; }
        public string LeadSource { get; set; }
        public string Email { get; set; }
        public string SecondaryPhone { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string ContactPerson { get; set; }
    }
}