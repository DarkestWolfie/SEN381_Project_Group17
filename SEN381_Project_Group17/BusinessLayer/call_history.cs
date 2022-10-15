using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEN381_Project_Group17.BusinessLayer
{
    internal class call_history
    {
        int callID, callCustomerID, callEmployeeID;
        DateTime strat, end, dateCreated;

        public call_history()
        {
        }

        public call_history(int callID, int callCustomerID, int callEmployeeID, DateTime strat, DateTime end, DateTime dateCreated)
        {
            this.CallID = callID;
            this.CallCustomerID = callCustomerID;
            this.CallEmployeeID = callEmployeeID;
            this.Strat = strat;
            this.End = end;
            this.DateCreated = dateCreated;
        }

        public int CallID { get => callID; set => callID = value; }
        public int CallCustomerID { get => callCustomerID; set => callCustomerID = value; }
        public int CallEmployeeID { get => callEmployeeID; set => callEmployeeID = value; }
        public DateTime Strat { get => strat; set => strat = value; }
        public DateTime End { get => end; set => end = value; }
        public DateTime DateCreated { get => dateCreated; set => dateCreated = value; }
    }
}
