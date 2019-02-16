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
    public class UniversityManager : BaseBusinessManager, IUniversity
    {
        public UniversityEntity FetchUniversityDetail(int universityid)
        {
            return SelectUniversity(universityid)[0];
        }

        public List<UniversityEntity> SelectUniversityList()
        {
            return SelectUniversity(0);
        }

        private List<UniversityEntity> SelectUniversity(int universityid)
        {
            List<UniversityEntity> lstUniversityEntity = new List<UniversityEntity>();
            UniversityEntity objUniversityEntity = new UniversityEntity();

            var contractorData = DataAccessHelper.KreativeBoxEntities.KB_SelectUniversity(universityid).ToList();
            if (contractorData.Any())
            {
                foreach (var item in contractorData)
                {
                    objUniversityEntity = new UniversityEntity
                    {
                        UniversityId = item.UniversityId,
                        UniversityName = item.UniversityName,
                        Address = item.Address,
                        Phone = item.Phone,
                        PrimaryPhone = item.PrimaryPhone,
                        Country = item.Country,
                        State = item.State,
                        City = item.City,
                        UniversityLogo = item.UniversityLogo,
                        LeadSource = item.LeadSource,
                        Email = item.Email,
                        SecondaryPhone = item.SecondaryPhone,
                        ContactPerson = item.ContactPerson,
                        IsDeleted = item.IsDeleted,
                        IsActive = item.IsActive
                    };
                    lstUniversityEntity.Add(objUniversityEntity);
                }
            }

            return lstUniversityEntity;
        }

        public int OperationUniversity(UniversityEntity objUniversity)
        {
            var returnParam = new ObjectParameter("ReturnCode", typeof(int));
            DataAccessHelper.KreativeBoxEntities.UniversityOperation(objUniversity.UniversityId, objUniversity.UniversityName,
                objUniversity.Address, objUniversity.Country, objUniversity.State, objUniversity.City, objUniversity.UniversityLogo,
                objUniversity.Email, objUniversity.Phone, objUniversity.PrimaryPhone, objUniversity.SecondaryPhone,
                objUniversity.LeadSource, objUniversity.CreatedBy, objUniversity.UpdatedBy, objUniversity.IsDeleted,
                objUniversity.IsActive, objUniversity.ContactPerson, returnParam);

            int resultId = Convert.IsDBNull(returnParam.Value) ? 0 : (int)returnParam.Value;
            return resultId;
        }

        public int OperationUniversityDelete(UniversityEntity objUniversity)
        {
            var returnParam = new ObjectParameter("ReturnCode", typeof(int));
            DataAccessHelper.KreativeBoxEntities.UniversityDelete(objUniversity.UniversityId, 
                objUniversity.UpdatedBy, returnParam);

            int resultId = Convert.IsDBNull(returnParam.Value) ? 0 : (int)returnParam.Value;
            return resultId;
        }
    }
}
