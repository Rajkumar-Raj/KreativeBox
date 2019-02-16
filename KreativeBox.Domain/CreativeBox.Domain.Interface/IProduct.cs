using CreativeBox.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeBox.Domain.Interface
{
    public interface IProduct
    {
        List<ProductEntity> SelectProductList();

        ProductEntity FetchProductDetail(int idproduct);

        int OperationProduct(ProductEntity objProductEntity);

        int OperationProductDelete(ProductEntity objProductEntity);
    }
}
