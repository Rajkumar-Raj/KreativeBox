using CreativeBox.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativeBox.Domain.Entity;
using System.Data.Entity.Core.Objects;

namespace CreativeBox.Data.BusinessLogic
{
    public class OrderManager : BaseBusinessManager, IOrder
    {
        public OrderEntity FetchOrderDetail(int Orderid)
        {
            return SelectOrder(Orderid)[0];
        }

        public List<OrderEntity> SelectOrderList()
        {
            return SelectOrder(0);
        }

        private List<OrderEntity> SelectOrder(int Orderid)
        {
            List<OrderEntity> lstOrderEntity = new List<OrderEntity>();
            OrderEntity objOrderEntity = new OrderEntity();

            var contractorData = DataAccessHelper.KreativeBoxEntities.KB_SelectOrder(Orderid).ToList();
            if (contractorData.Any())
            {
                foreach (var item in contractorData)
                {
                    objOrderEntity = new OrderEntity
                    {
                        OrderId = item.OrderId,
                        QuotationId = item.QuotationId,
                        AgentName = item.AgentName,
                        ProductName = item.ProductName,
                        Quantity = item.Quantity,
                        Price = item.Price,
                        ProductReference = item.ProductReference,
                        WareHouse = item.WareHouse,
                        ProductId = item.ProductId,
                        DeliverAddress = item.DeliverAddress,
                        ContactPerson = item.ContactPerson,
                        ContactNo = item.ContactNo,
                        Country = item.Country,
                        State = item.State,
                        City = item.City,
                        CreatedDate = item.CreatedDate,
                        IsDeleted = item.IsDeleted,
                        IsActive = item.IsActive
                    };
                    lstOrderEntity.Add(objOrderEntity);
                }
            }

            return lstOrderEntity;
        }

        public int OperationOrder(OrderEntity objOrder)
        {
            var returnParam = new ObjectParameter("ReturnCode", typeof(int));
            DataAccessHelper.KreativeBoxEntities.KB_Order_Insert_Update(objOrder.OrderId, objOrder.QuotationId,
                objOrder.AgentName, objOrder.ProductName, objOrder.Quantity, objOrder.Price, objOrder.ProductReference,
                objOrder.WareHouse, objOrder.ProductId, objOrder.DeliverAddress, objOrder.ContactPerson,
                objOrder.ContactNo,objOrder.Country,objOrder.State,objOrder.City, objOrder.CreatedBy, 
                objOrder.UpdatedBy, objOrder.IsDeleted, objOrder.IsActive, returnParam);

            int resultId = Convert.IsDBNull(returnParam.Value) ? 0 : (int)returnParam.Value;
            return resultId;
        }

        public int OperationOrderDelete(OrderEntity objOrder)
        {
            var returnParam = new ObjectParameter("ReturnCode", typeof(int));
            DataAccessHelper.KreativeBoxEntities.KB_Order_Delete(objOrder.OrderId,
                objOrder.UpdatedBy, returnParam);

            int resultId = Convert.IsDBNull(returnParam.Value) ? 0 : (int)returnParam.Value;
            return resultId;
        }

        public List<DataPoint> SelectOrderReport()
        {
            List<DataPoint> lstOrderEntity = new List<DataPoint>();
            
            var contractorData = DataAccessHelper.KreativeBoxEntities.KB_OrderReportByQuantity().ToList();
            if (contractorData.Any())
            {
                foreach (var item in contractorData)
                {
                    lstOrderEntity.Add(new DataPoint(item.Month, Convert.ToDouble(item.Quantity)));
                }
            }

            return lstOrderEntity;
        }



        public QuotationEntity FetchQuotationDetail(int Quotationid)
        {
            return SelectQuotation(Quotationid)[0];
        }

        public List<QuotationEntity> SelectQuotationList()
        {
            return SelectQuotation(0);
        }

        private List<QuotationEntity> SelectQuotation(int Quotationid)
        {
            List<QuotationEntity> lstQuotationEntity = new List<QuotationEntity>();
            QuotationEntity objQuotationEntity = new QuotationEntity();

            var contractorData = DataAccessHelper.KreativeBoxEntities.KB_SelectQuotation(Quotationid).ToList();
            if (contractorData.Any())
            {
                foreach (var item in contractorData)
                {
                    objQuotationEntity = new QuotationEntity
                    {
                        QuotationId = item.QuotationId,
                        OrderId = item.OrderId,
                        ProductName = item.ProductName,
                        Variation = item.Variation,
                        ProductReference = item.ProductReference,
                        Process = item.Process,
                        QuotationType = item.QuotationType,
                        ProofingMethod = item.ProofingMethod,
                        Specification = item.Specification,
                        Comments = item.Comments,
                        Quantity = item.Quantity,
                        InvoiceRecipient = item.InvoiceRecipient,
                        Status = item.Status,
                        CreatedDate = item.CreatedDate,
                        IsDeleted = item.IsDeleted,
                        IsActive = item.IsActive
                    };
                    lstQuotationEntity.Add(objQuotationEntity);
                }
            }

            return lstQuotationEntity;
        }

        public int OperationQuotation(QuotationEntity objQuotation)
        {
            var returnParam = new ObjectParameter("ReturnCode", typeof(int));
            DataAccessHelper.KreativeBoxEntities.KB_Quotation_Insert_Update(objQuotation.QuotationId, objQuotation.OrderId,
                objQuotation.ProductName, objQuotation.Variation, objQuotation.ProductReference, objQuotation.Process, objQuotation.QuotationType,
                objQuotation.ProofingMethod, objQuotation.Specification, objQuotation.Comments, objQuotation.Quantity,
                objQuotation.InvoiceRecipient,objQuotation.Status, objQuotation.CreatedBy, objQuotation.UpdatedBy, objQuotation.IsDeleted,
                objQuotation.IsActive, returnParam);

            int resultId = Convert.IsDBNull(returnParam.Value) ? 0 : (int)returnParam.Value;
            return resultId;
        }

        public int OperationQuotationDelete(QuotationEntity objQuotation)
        {
            var returnParam = new ObjectParameter("ReturnCode", typeof(int));
            DataAccessHelper.KreativeBoxEntities.KB_Quotation_Delete(objQuotation.QuotationId,
                objQuotation.UpdatedBy, returnParam);

            int resultId = Convert.IsDBNull(returnParam.Value) ? 0 : (int)returnParam.Value;
            return resultId;
        }



        public AddressEntity FetchAddressDetail(int Addressid)
        {
            return SelectAddress(Addressid)[0];
        }

        public List<AddressEntity> SelectAddressList()
        {
            return SelectAddress(0);
        }

        private List<AddressEntity> SelectAddress(int Addressid)
        {
            List<AddressEntity> lstAddressEntity = new List<AddressEntity>();
            AddressEntity objAddressEntity = new AddressEntity();

            var contractorData = DataAccessHelper.KreativeBoxEntities.KB_SelectAddressSetting(Addressid).ToList();
            if (contractorData.Any())
            {
                foreach (var item in contractorData)
                {
                    objAddressEntity = new AddressEntity
                    {
                        AddressId = item.AddressId,
                        Company = item.Company,
                        ContactName = item.ContactName,
                        Phone = item.Phone,
                        AddressLine1 = item.AddressLine1,
                        Country = item.Country,
                        State = item.State,
                        City = item.City,
                        AddressLine2 = item.AddressLine2,
                        ZipCode = item.ZipCode,
                        CreatedDate = item.CreatedDate,                        
                        IsDeleted = item.IsDeleted,
                        IsActive = item.IsActive
                    };
                    lstAddressEntity.Add(objAddressEntity);
                }
            }

            return lstAddressEntity;
        }

        public int OperationAddress(AddressEntity objAddress)
        {
            var returnParam = new ObjectParameter("ReturnCode", typeof(int));
            DataAccessHelper.KreativeBoxEntities.KB_AddressSetting_Insert_Update(objAddress.AddressId, objAddress.Company,
                objAddress.ContactName, objAddress.Country, objAddress.State, objAddress.City, objAddress.AddressLine1,
                objAddress.AddressLine2, objAddress.ZipCode, objAddress.Phone, objAddress.CreatedBy, objAddress.UpdatedBy, 
                objAddress.IsDeleted, objAddress.IsActive, returnParam);

            int resultId = Convert.IsDBNull(returnParam.Value) ? 0 : (int)returnParam.Value;
            return resultId;
        }

        public int OperationAddressDelete(AddressEntity objAddress)
        {
            var returnParam = new ObjectParameter("ReturnCode", typeof(int));
            DataAccessHelper.KreativeBoxEntities.KB_AddressSetting_Delete(objAddress.AddressId,
                objAddress.UpdatedBy, returnParam);

            int resultId = Convert.IsDBNull(returnParam.Value) ? 0 : (int)returnParam.Value;
            return resultId;
        }        
    }
}
