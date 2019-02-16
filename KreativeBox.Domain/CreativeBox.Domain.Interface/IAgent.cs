using CreativeBox.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeBox.Domain.Interface
{
    public interface IAgent
    {
        List<AgentEntity> SelectAgentList();

        AgentEntity FetchAgentDetail(int agentid);

        int OperationAgent(AgentEntity objAgentEntity);

        int OperationAgentDelete(AgentEntity objAgentEntity);
    }
}
