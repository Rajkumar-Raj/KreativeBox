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
    public class AgentManager : BaseBusinessManager, IAgent
    {
        public AgentEntity FetchAgentDetail(int agentid)
        {
            return SelectAgent(agentid)[0];
        }

        public List<AgentEntity> SelectAgentList()
        {
            return SelectAgent(0);
        }

        private List<AgentEntity> SelectAgent(int agentid)
        {
            List<AgentEntity> lstAgentEntity = new List<AgentEntity>();
            AgentEntity objAgentEntity = new AgentEntity();

            var contractorData = DataAccessHelper.KreativeBoxEntities.KB_SelectAgent(agentid).ToList();
            if (contractorData.Any())
            {
                foreach (var item in contractorData)
                {
                    objAgentEntity = new AgentEntity
                    {
                        AgentId = item.AgentId,
                        AgentName = item.AgentName,
                        Address = item.Address,
                        Phone = item.Phone,
                        PrimaryPhone = item.PrimaryPhone,
                        Country = item.Country,
                        State = item.State,
                        City = item.City,
                        AgentLogo = item.AgentLogo,
                        Website = item.Website,
                        Email = item.Email,                        
                        IsDeleted = item.IsDeleted,
                        IsActive = item.IsActive
                    };
                    lstAgentEntity.Add(objAgentEntity);
                }
            }

            return lstAgentEntity;
        }

        public int OperationAgent(AgentEntity objAgent)
        {
            var returnParam = new ObjectParameter("ReturnCode", typeof(int));
            DataAccessHelper.KreativeBoxEntities.AgentOperation(objAgent.AgentId, objAgent.AgentName,
                objAgent.Address, objAgent.Country, objAgent.State, objAgent.City, objAgent.Website,
                objAgent.AgentLogo, objAgent.Email, objAgent.Phone, objAgent.PrimaryPhone,
                objAgent.CreatedBy, objAgent.UpdatedBy, objAgent.IsDeleted,
                objAgent.IsActive, returnParam);

            int resultId = Convert.IsDBNull(returnParam.Value) ? 0 : (int)returnParam.Value;
            return resultId;
        }

        public int OperationAgentDelete(AgentEntity objAgent)
        {
            var returnParam = new ObjectParameter("ReturnCode", typeof(int));
            DataAccessHelper.KreativeBoxEntities.AgentDelete(objAgent.AgentId,
                objAgent.UpdatedBy, returnParam);

            int resultId = Convert.IsDBNull(returnParam.Value) ? 0 : (int)returnParam.Value;
            return resultId;
        }
    }
}
