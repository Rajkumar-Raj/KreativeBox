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
    public class WareHouseManager : BaseBusinessManager, IWareHouse
    {
        public WareHouseEntity FetchWareHouseDetail(int WareHouseid)
        {
            return SelectWareHouse(WareHouseid)[0];
        }

        public List<WareHouseEntity> SelectWareHouseList()
        {
            return SelectWareHouse(0);
        }

        private List<WareHouseEntity> SelectWareHouse(int WareHouseid)
        {
            List<WareHouseEntity> lstWareHouseEntity = new List<WareHouseEntity>();
            WareHouseEntity objWareHouseEntity = new WareHouseEntity();

            var contractorData = DataAccessHelper.KreativeBoxEntities.KB_SelectWareHouse(WareHouseid).ToList();
            if (contractorData.Any())
            {
                foreach (var item in contractorData)
                {
                    objWareHouseEntity = new WareHouseEntity
                    {
                        WareHouseId = item.WareHouseId,
                        WareHouseName = item.WareHouseName,
                        Address = item.Address,
                        Country = item.Country,
                        State = item.State,
                        City = item.City,
                        Phone = item.Phone,
                        PrimaryPhone = item.PrimaryPhone,                        
                        IsDeleted = item.IsDeleted,
                        IsActive = item.IsActive
                    };
                    lstWareHouseEntity.Add(objWareHouseEntity);
                }
            }

            return lstWareHouseEntity;
        }

        public int OperationWareHouse(WareHouseEntity objWareHouse)
        {
            var returnParam = new ObjectParameter("ReturnCode", typeof(int));
            DataAccessHelper.KreativeBoxEntities.WareHouseOperation(objWareHouse.WareHouseId, objWareHouse.WareHouseName,
                objWareHouse.Address, objWareHouse.Country, objWareHouse.State, objWareHouse.City, objWareHouse.Phone,
                objWareHouse.PrimaryPhone, objWareHouse.CreatedBy, objWareHouse.UpdatedBy, objWareHouse.IsDeleted,
                objWareHouse.IsActive, returnParam);

            int resultId = Convert.IsDBNull(returnParam.Value) ? 0 : (int)returnParam.Value;
            return resultId;
        }

        public int OperationWareHouseDelete(WareHouseEntity objWareHouse)
        {
            var returnParam = new ObjectParameter("ReturnCode", typeof(int));
            DataAccessHelper.KreativeBoxEntities.WareHouseDelete(objWareHouse.WareHouseId,
                objWareHouse.UpdatedBy, returnParam);

            int resultId = Convert.IsDBNull(returnParam.Value) ? 0 : (int)returnParam.Value;
            return resultId;
        }
    }
}
