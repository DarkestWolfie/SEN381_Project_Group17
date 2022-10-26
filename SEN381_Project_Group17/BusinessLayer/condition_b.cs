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
        String conditionName, conditionCode;

        public condition_b()
        {
        }

        public condition_b(int conditionID, int conditionPolicyID, string conditionCode, string conditionName)
        {
            this.ConditionID = conditionID;
            this.ConditionPolicyID = conditionPolicyID;
            this.conditionCode = conditionCode;
            this.ConditionName = conditionName;
        }

        public int ConditionID { get => conditionID; set => conditionID = value; }
        public int ConditionPolicyID { get => conditionPolicyID; set => conditionPolicyID = value; }
        public string ConditionName { get => conditionName; set => conditionName = value; }
        public string ConditionCode { get => conditionCode; set => conditionCode = value; }
    }
}
