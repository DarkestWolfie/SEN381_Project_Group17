using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEN381_Project_Group17.BusinessLayer
{
    internal class call_history_b
    {
        int callID, callEmployeeID;
        String callCustomerID;
        String strat, end, dateCreated, duration;

        public call_history_b()
        {
        }

        public call_history_b(int callID, string callCustomerID, int callEmployeeID, string strat, string end, string dateCreated, string duration)
        {
            this.CallID = callID;
            this.CallCustomerID = callCustomerID;
            this.CallEmployeeID = callEmployeeID;
            this.Strat = strat;
            this.End = end;
            this.DateCreated = dateCreated;
            this.Duration = duration;
        }

        public int CallID { get => callID; set => callID = value; }
        public string CallCustomerID { get => callCustomerID; set => callCustomerID = value; }
        public int CallEmployeeID { get => callEmployeeID; set => callEmployeeID = value; }
        public string Strat { get => strat; set => strat = value; }
        public string End { get => end; set => end = value; }
        public String DateCreated { get => dateCreated; set => dateCreated = value; }
        public string Duration { get => duration; set => duration = value; }
    }
}
