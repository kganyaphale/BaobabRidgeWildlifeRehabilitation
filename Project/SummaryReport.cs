using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    /// <summary>
    /// Holds the summary statistics for all the animals in animals.txt.
    /// </summary>
    public class SummaryReport
    {
        public int TotalAnimals { get; set; }
        public double AverageAge { get; set; }
        public double AverageScore { get; set; }
        public int CriticalCount { get; set; }
        public int SeriousCount { get; set; }
        public int StableCount { get; set; }
        public int RecoveringCount { get; set; }
        public int ReleaseReadyCount { get; set; }

        /// <summary>
        /// Works out the total, the two averages and how many animals are in each status.
        /// </summary>
        public void Calculate(List<Animal> animals)
        {
            TotalAnimals = animals.Count;

            int totalAge = 0;
            int totalScore = 0;

            foreach (Animal animal in animals)
            {
                totalAge = totalAge + animal.Age;
                totalScore = totalScore + animal.RecoveryScore;

                // Count the animal under its status
                if (animal.Status == "Critical")
                {
                    CriticalCount++;
                }
                else if (animal.Status == "Serious")
                {
                    SeriousCount++;
                }
                else if (animal.Status == "Stable")
                {
                    StableCount++;
                }
                else if (animal.Status == "Recovering")
                {
                    RecoveringCount++;
                }
                else if (animal.Status == "Release-Ready")
                {
                    ReleaseReadyCount++;
                }
            }

            // Only divide if there are animals, otherwise we would divide by 0
            if (TotalAnimals > 0)
            {
                // (double) stops C# from doing whole-number division and cutting off the decimals
                AverageAge = (double)totalAge / TotalAnimals;
                AverageScore = (double)totalScore / TotalAnimals;
            }
        }

        /// <summary>
        /// Returns an average as text with 2 decimals and a full stop, or N/A when there are no animals.
        /// </summary>
        public string FormatAverage(double average)
        {
            if (TotalAnimals == 0)
            {
                return "N/A";
            }

            // InvariantCulture makes sure a full stop is used, because South African
            // regional settings would show a comma instead (7,75 instead of 7.75)
            return average.ToString("0.00", CultureInfo.InvariantCulture);
        }
    }
}
