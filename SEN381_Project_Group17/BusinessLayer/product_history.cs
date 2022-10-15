using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEN381_Project_Group17.BusinessLayer
{
    internal class product_history
    {
        int porHistoryID, historyProductID;
        DateTime start, end;

        public product_history()
        {
        }

        public product_history(int porHistoryID, int historyProductID, DateTime start, DateTime end)
        {
            this.PorHistoryID = porHistoryID;
            this.HistoryProductID = historyProductID;
            this.Start = start;
            this.End = end;
        }

        public int PorHistoryID { get => porHistoryID; set => porHistoryID = value; }
        public int HistoryProductID { get => historyProductID; set => historyProductID = value; }
        public DateTime Start { get => start; set => start = value; }
        public DateTime End { get => end; set => end = value; }
    }
}
