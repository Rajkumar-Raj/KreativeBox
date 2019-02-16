using CreativeBox.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeBox.Domain.Interface
{
    public interface IWareHouse
    {
        List<WareHouseEntity> SelectWareHouseList();

        WareHouseEntity FetchWareHouseDetail(int warehouseid);

        int OperationWareHouse(WareHouseEntity objWareHouseEntity);

        int OperationWareHouseDelete(WareHouseEntity objWareHouseEntity);
    }
}
