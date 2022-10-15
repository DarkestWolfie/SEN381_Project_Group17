using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEN381_Project_Group17.BusinessLayer
{
    internal class condition
    {
        int conditionID, conditionPolicyID;
        String conditionName;

        public condition()
        {
        }

        public condition(int conditionID, int conditionPolicyID, string conditionName)
        {
            this.conditionID = conditionID;
            this.conditionPolicyID = conditionPolicyID;
            this.conditionName = conditionName;
        }
    }
}
