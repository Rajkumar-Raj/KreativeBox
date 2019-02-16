using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CreativeBox.Domain.Entity
{
    public class QuotationEntity
    {
        [DataMember]
        public long? QuotationId { get; set; }
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string Variation { get; set; }
        [DataMember]
        public string ProductReference { get; set; }
        [DataMember]
        public string Process { get; set; }
        [DataMember]
        public string QuotationType { get; set; }
        [DataMember]
        public string ProofingMethod { get; set; }
        [DataMember]
        public string Specification { get; set; }
        [DataMember]
        public string Comments { get; set; }
        [DataMember]
        public int? Quantity { get; set; }
        [DataMember]
        public string InvoiceRecipient { get; set; }
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
        public string Status { get; set; }
    }
}
