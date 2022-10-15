using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEN381_Project_Group17.BusinessLayer
{
    internal class customer_history
    {
        int cusHistoryID, historyCustomerID, historyProductHistory;
        DateTime start, end;
        String active;

        public customer_history()
        {
        }

        public customer_history(int cusHistoryID, int historyCustomerID, int historyProductHistory, DateTime start, DateTime end, string active)
        {
            this.CusHistoryID = cusHistoryID;
            this.HistoryCustomerID = historyCustomerID;
            this.HistoryProductHistory = historyProductHistory;
            this.Start = start;
            this.End = end;
            this.Active = active;
        }

        public int CusHistoryID { get => cusHistoryID; set => cusHistoryID = value; }
        public int HistoryCustomerID { get => historyCustomerID; set => historyCustomerID = value; }
        public int HistoryProductHistory { get => historyProductHistory; set => historyProductHistory = value; }
        public DateTime Start { get => start; set => start = value; }
        public DateTime End { get => end; set => end = value; }
        public string Active { get => active; set => active = value; }
    }
}
