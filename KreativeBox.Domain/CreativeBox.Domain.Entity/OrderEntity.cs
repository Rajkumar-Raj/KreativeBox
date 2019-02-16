using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CreativeBox.Domain.Entity
{
    public class OrderEntity
    {
        [DataMember]
        public long? OrderId { get; set; }
        [DataMember]
        public long? QuotationId { get; set; }
        [DataMember]
        public string AgentName { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public int? Quantity { get; set; }
        [DataMember]
        public decimal? Price { get; set; }
        [DataMember]
        public string ProductReference { get; set; }
        [DataMember]
        public string WareHouse { get; set; }
        [DataMember]
        public string ProductId { get; set; }
        [DataMember]
        public string DeliverAddress { get; set; }
        [DataMember]
        public string ContactPerson { get; set; }
        [DataMember]
        public string ContactNo { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string City { get; set; }
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
