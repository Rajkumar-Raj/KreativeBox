using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CreativeBox.Domain.Entity
{
    public class AgentEntity
    {
        [DataMember]
        public long? AgentId { get; set; }
        [DataMember]
        public string AgentName { get; set; }
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
        public string AgentLogo { get; set; }
        [DataMember]
        public string Website { get; set; }
        [DataMember]
        public string Email { get; set; }        
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
    }
}
