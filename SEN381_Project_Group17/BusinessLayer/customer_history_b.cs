using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEN381_Project_Group17.BusinessLayer
{
    internal class customer_history_b
    {
        int cusHistoryID, historyProductHistory;
        String active, historyCustomerID, start, end;

        public customer_history_b()
        {
        }

        public customer_history_b(int cusHistoryID, string historyCustomerID, int historyProductHistory, string start, string end, string active)
        {
            this.CusHistoryID = cusHistoryID;
            this.HistoryCustomerID = historyCustomerID;
            this.HistoryProductHistory = historyProductHistory;
            this.Start = start;
            this.End = end;
            this.Active = active;
        }

        public int CusHistoryID { get => cusHistoryID; set => cusHistoryID = value; }
        public string HistoryCustomerID { get => historyCustomerID; set => historyCustomerID = value; }
        public int HistoryProductHistory { get => historyProductHistory; set => historyProductHistory = value; }
        public string Start { get => start; set => start = value; }
        public string End { get => end; set => end = value; }
        public string Active { get => active; set => active = value; }
    }
}
