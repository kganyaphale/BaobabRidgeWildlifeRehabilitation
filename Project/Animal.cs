using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    /// <summary>
    /// Represents one animal at the Baobab Ridge rehabilitation centre.
    /// Also contains the single classification method used by both Add and Update.
    /// </summary>
    public class Animal
    {
        public string AnimalID { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public int RecoveryScore { get; set; }
        public string Status { get; set; }
        public string HousingUnit { get; set; }

        /// <summary>
        /// Works out the Status and Housing Unit from the Recovery Score (Section 4 of the brief).
        /// This is the only place the classification rules are written.
        /// </summary>
        public void DetermineStatusAndHousing()
        {
            if (RecoveryScore >= 0 && RecoveryScore <= 19)
            {
                Status = "Critical";
                HousingUnit = "Intensive Care Unit";
            }
            else if (RecoveryScore >= 20 && RecoveryScore <= 39)
            {
                Status = "Serious";
                HousingUnit = "High-Dependency Ward";
            }
            else if (RecoveryScore >= 40 && RecoveryScore <= 59)
            {
                Status = "Stable";
                HousingUnit = "Recovery Ward";
            }
            else if (RecoveryScore >= 60 && RecoveryScore <= 79)
            {
                Status = "Recovering";
                HousingUnit = "Outdoor Enclosure";
            }
            else if (RecoveryScore >= 80 && RecoveryScore <= 100)
            {
                Status = "Release-Ready";
                HousingUnit = "Pre-Release Camp";
            }
        }
    }
}
