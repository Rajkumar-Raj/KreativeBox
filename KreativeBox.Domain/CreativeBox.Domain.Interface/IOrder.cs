using CreativeBox.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeBox.Domain.Interface
{
    public interface IOrder
    {
        List<OrderEntity> SelectOrderList();

        OrderEntity FetchOrderDetail(int orderid);

        int OperationOrder(OrderEntity objOrderEntity);

        int OperationOrderDelete(OrderEntity objOrderEntity);

        List<DataPoint> SelectOrderReport();


        List<QuotationEntity> SelectQuotationList();

        QuotationEntity FetchQuotationDetail(int quotationid);

        int OperationQuotation(QuotationEntity objQuotationEntity);

        int OperationQuotationDelete(QuotationEntity objQuotationEntity);


        List<AddressEntity> SelectAddressList();

        AddressEntity FetchAddressDetail(int addressid);

        int OperationAddress(AddressEntity objAddressEntity);

        int OperationAddressDelete(AddressEntity objAddressEntity);
    }
}
