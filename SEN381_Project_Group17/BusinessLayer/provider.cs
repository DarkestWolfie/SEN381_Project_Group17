using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEN381_Project_Group17.BusinessLayer
{
    internal class provider
    {
        int providerID;
        String providerName, status, province;

        public provider()
        {
        }

        public provider(int providerID, string providerName, string status, string province)
        {
            this.ProviderID = providerID;
            this.ProviderName = providerName;
            this.Status = status;
            this.Province = province;
        }

        public int ProviderID { get => providerID; set => providerID = value; }
        public string ProviderName { get => providerName; set => providerName = value; }
        public string Status { get => status; set => status = value; }
        public string Province { get => province; set => province = value; }
    }
}
