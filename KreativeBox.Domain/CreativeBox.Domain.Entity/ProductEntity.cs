using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CreativeBox.Domain.Entity
{
    public class ProductEntity
    {
        [DataMember]
        public long? ProductAutoId { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string ProductId { get; set; }
        [DataMember]
        public string StandardBPO { get; set; }
        [DataMember]
        public int? Quantity { get; set; }
        [DataMember]
        public string WareHouseName { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Department { get; set; }
        [DataMember]
        public string HsCode { get; set; }
        [DataMember]
        public string Weight { get; set; }
        [DataMember]
        public decimal? Price { get; set; }
        [DataMember]
        public string DisplayOrder { get; set; }
        [DataMember]
        public string ProductReference { get; set; }
        [DataMember]
        public decimal? UnitPrice { get; set; }
        [DataMember]
        public string Currency { get; set; }
        [DataMember]
        public string ProductImage { get; set; }
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
