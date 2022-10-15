using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEN381_Project_Group17.BusinessLayer
{
    internal class treatment
    {
        int treatmentID, treatmentConditionID, treatmentProviderID;
        String treatmentName, description;
        Double cost;

        public treatment()
        {
        }

        public treatment(int treatmentID, int treatmentConditionID, int treatmentProviderID, string treatmentName, string description, double cost)
        {
            this.TreatmentID = treatmentID;
            this.TreatmentConditionID = treatmentConditionID;
            this.TreatmentProviderID = treatmentProviderID;
            this.TreatmentName = treatmentName;
            this.Description = description;
            this.Cost = cost;
        }

        public int TreatmentID { get => treatmentID; set => treatmentID = value; }
        public int TreatmentConditionID { get => treatmentConditionID; set => treatmentConditionID = value; }
        public int TreatmentProviderID { get => treatmentProviderID; set => treatmentProviderID = value; }
        public string TreatmentName { get => treatmentName; set => treatmentName = value; }
        public string Description { get => description; set => description = value; }
        public double Cost { get => cost; set => cost = value; }
    }
}
