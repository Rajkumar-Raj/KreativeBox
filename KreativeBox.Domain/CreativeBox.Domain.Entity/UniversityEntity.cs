using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CreativeBox.Domain.Entity
{
    public class UniversityEntity
    {
        [DataMember]
        public long? UniversityId { get; set; }
        [DataMember]
        public string UniversityName { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string PrimaryPhone { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string UniversityLogo { get; set; }
        [DataMember]
        public string LeadSource { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string SecondaryPhone { get; set; }
        [DataMember]
        public int? CreatedBy { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public int? UpdatedBy { get; set; }
        [DataMember]
        public DateTime? UpdatedDate { get; set; }
        [DataMember]
        public bool? IsDeleted { get; set; }
        [DataMember]
        public bool? IsActive { get; set; }   
        [DataMember]
        public string ContactPerson { get; set; }
    }
}
