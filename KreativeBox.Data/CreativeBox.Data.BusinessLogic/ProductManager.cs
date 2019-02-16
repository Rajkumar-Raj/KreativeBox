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
    public class ProductManager : BaseBusinessManager, IProduct
    {
        public ProductEntity FetchProductDetail(int Productid)
        {
            return SelectProduct(Productid)[0];
        }

        public List<ProductEntity> SelectProductList()
        {
            return SelectProduct(0);
        }

        private List<ProductEntity> SelectProduct(int Productid)
        {
            List<ProductEntity> lstProductEntity = new List<ProductEntity>();
            ProductEntity objProductEntity = new ProductEntity();

            var contractorData = DataAccessHelper.KreativeBoxEntities.KB_SelectProduct(Productid).ToList();
            if (contractorData.Any())
            {
                foreach (var item in contractorData)
                {
                    objProductEntity = new ProductEntity
                    {
                        ProductAutoId = item.ProductAutoId,
                        ProductName = item.ProductName,
                        ProductId = item.ProductId,
                        StandardBPO = item.StandardBPO,
                        Quantity = item.Quantity,
                        WareHouseName = item.WareHouseName,
                        Address = item.Address,
                        Country = item.Country,
                        State = item.state,
                        City = item.City,
                        Department = item.Department,
                        HsCode = item.HsCode,
                        Weight = item.Weight,
                        Price = item.Price,
                        DisplayOrder = item.DisplayOrder,
                        ProductReference = item.ProductReference,
                        UnitPrice = item.UnitPrice,
                        Currency = item.Currency,
                        ProductImage = item.ProductImage,
                        CreatedDate = item.CreatedDate,
                        IsDeleted = item.IsDeleted,
                        IsActive = item.IsActive
                    };
                    lstProductEntity.Add(objProductEntity);
                }
            }

            return lstProductEntity;
        }

        public int OperationProduct(ProductEntity objProduct)
        {
            var returnParam = new ObjectParameter("ReturnCode", typeof(int));
            DataAccessHelper.KreativeBoxEntities.KB_Product_Insert_Update(objProduct.ProductAutoId, objProduct.ProductName,
                objProduct.ProductId, objProduct.StandardBPO, objProduct.Quantity, objProduct.WareHouseName, objProduct.Address,
                objProduct.Country, objProduct.State, objProduct.City, objProduct.Department,
                objProduct.HsCode, objProduct.Weight, objProduct.Price, objProduct.DisplayOrder,
                objProduct.ProductReference, objProduct.UnitPrice, objProduct.Currency,
                objProduct.ProductImage, objProduct.CreatedBy,objProduct.UpdatedBy,
                objProduct.IsDeleted,objProduct.IsActive, returnParam);

            int resultId = Convert.IsDBNull(returnParam.Value) ? 0 : (int)returnParam.Value;
            return resultId;
        }

        public int OperationProductDelete(ProductEntity objProduct)
        {
            var returnParam = new ObjectParameter("ReturnCode", typeof(int));
            DataAccessHelper.KreativeBoxEntities.KB_Product_Delete(objProduct.ProductAutoId,
                objProduct.UpdatedBy, returnParam);

            int resultId = Convert.IsDBNull(returnParam.Value) ? 0 : (int)returnParam.Value;
            return resultId;
        }
    }
}
