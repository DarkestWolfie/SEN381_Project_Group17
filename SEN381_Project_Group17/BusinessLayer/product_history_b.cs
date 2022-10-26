﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEN381_Project_Group17.BusinessLayer
{
    internal class product_history_b
    {
        int porHistoryID, historyProductID;
        String start, end;

        public product_history_b()
        {
        }

        public product_history_b(int porHistoryID, int historyProductID, string start, string end)
        {
            this.PorHistoryID = porHistoryID;
            this.HistoryProductID = historyProductID;
            this.Start = start;
            this.End = end;
        }

        public int PorHistoryID { get => porHistoryID; set => porHistoryID = value; }
        public int HistoryProductID { get => historyProductID; set => historyProductID = value; }
        public string Start { get => start; set => start = value; }
        public string End { get => end; set => end = value; }
    }
}
