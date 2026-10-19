using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class FileHandler
    {
        private readonly string filePath = "animals.txt";

        public List<Animal> LoadAnimals()
        {
            List<Animal> animals = new List<Animal>();
            int skippedLines = 0;

            try
            {
                // Auto-create empty animals.txt if missing without throwing errors
                if (!System.IO.File.Exists(filePath))
                {
                    System.IO.File.Create(filePath).Close();
                    return animals;
                }

                string[] lines = System.IO.File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');

                    // Check for wrong number of fields
                    if (parts.Length != 7)
                    {
                        skippedLines++;
                        continue;
                    }

                    string id = parts[0].Trim();
                    string name = parts[1].Trim();
                    string species = parts[2].Trim();

                    // Validate ID format
                    if (!System.Text.RegularExpressions.Regex.IsMatch(id, @"^WR-\d{4}$"))
                    {
                        skippedLines++;
                        continue;
                    }

                    // Check for non-numeric age or score
                    if (!int.TryParse(parts[3].Trim(), out int age) || !int.TryParse(parts[4].Trim(), out int score))
                    {
                        skippedLines++;
                        continue;
                    }

                    Animal newAnimal = new Animal
                    {
                        AnimalID = id,
                        Name = name,
                        Species = species,
                        Age = age,
                        RecoveryScore = score,
                        Status = parts[5].Trim(),
                        HousingUnit = parts[6].Trim()
                    };

                    animals.Add(newAnimal);
                }

                // Display skipped line count once after loading
                if (skippedLines > 0)
                {
                    System.Windows.Forms.MessageBox.Show($"{skippedLines} malformed line(s) were skipped during loading.", "Data Load Warning", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                }
            }
            catch (System.IO.IOException ex)
            {
                System.Windows.Forms.MessageBox.Show("The file is currently in use by another program. Please close it and try again.\n\nDetails: " + ex.Message, "File Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            catch (System.UnauthorizedAccessException ex)
            {
                System.Windows.Forms.MessageBox.Show("You do not have permission to access the file.\n\nDetails: " + ex.Message, "Permission Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("An unexpected error occurred while loading the data.\n\nDetails: " + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return animals;
        }
    }
}
