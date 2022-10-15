using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEN381_Project_Group17.BusinessLayer
{
    internal class condition_b
    {
        int conditionID, conditionPolicyID;
        String conditionName;

        public condition_b()
        {
        }

        public condition_b(int conditionID, int conditionPolicyID, string conditionName)
        {
            this.conditionID = conditionID;
            this.conditionPolicyID = conditionPolicyID;
            this.conditionName = conditionName;
        }
    }
}
