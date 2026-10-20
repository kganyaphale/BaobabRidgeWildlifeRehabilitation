using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        /// <summary>
        /// Writes the report to summary.txt in the same folder as the .exe.
        /// The old file is replaced every time. Returns true if the file was saved.
        /// </summary>
        public bool SaveToFile()
        {
            // Application.StartupPath is the folder the .exe is running from
            string summaryPath = Path.Combine(Application.StartupPath, "summary.txt");

            // Every label is padded to 29 characters so all the numbers line up in one column
            int column = 29;

            // Separator line between the sections of the report
            string separator = "----------------------------------------";

            try
            {
                // false = overwrite the file instead of adding to the end of it
                using (StreamWriter writer = new StreamWriter(summaryPath, false))
                {
                    writer.WriteLine("BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE");
                    writer.WriteLine("ANIMAL SUMMARY REPORT");
                    writer.WriteLine("Generated: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture));
                    writer.WriteLine(separator);
                    writer.WriteLine("Total animals:".PadRight(column) + TotalAnimals);
                    writer.WriteLine("Average age (years):".PadRight(column) + FormatAverage(AverageAge));
                    writer.WriteLine("Average recovery score:".PadRight(column) + FormatAverage(AverageScore));
                    writer.WriteLine(separator);
                    writer.WriteLine("Animals per status:");
                    writer.WriteLine("  Critical:".PadRight(column) + CriticalCount);
                    writer.WriteLine("  Serious:".PadRight(column) + SeriousCount);
                    writer.WriteLine("  Stable:".PadRight(column) + StableCount);
                    writer.WriteLine("  Recovering:".PadRight(column) + RecoveringCount);
                    writer.WriteLine("  Release-Ready:".PadRight(column) + ReleaseReadyCount);
                }

                return true;
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("The folder for summary.txt could not be found, so the summary was not saved.", "Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                MessageBox.Show("summary.txt is open in another program. Close it and try again.", "File In Use", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You do not have permission to save summary.txt (it may be read-only).", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}
