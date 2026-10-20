using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    /// <summary>
    /// Handles data parsing and file operations for the animals.txt database.
    /// Includes error handling for missing files and safely skips malformed text lines.
    /// </summary>
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

        /// <summary>
        /// Removes the animal with the given ID from animals.txt.
        /// Every other line is written back exactly as it was.
        /// Returns true if the animal was found and the file was saved.
        /// </summary>
        public bool DeleteAnimal(string animalID)
        {
            bool deleted = false;

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                List<string> linesToKeep = new List<string>();
                bool found = false;

                foreach (string line in lines)
                {
                    // Leave out blank lines so the file never contains any
                    if (line.Trim() == "")
                    {
                        continue;
                    }

                    string[] parts = line.Split('|');

                    // The ID is always the first field, so only that field is compared
                    if (parts[0].Trim() == animalID)
                    {
                        found = true; // this line is NOT added, which removes it
                    }
                    else
                    {
                        linesToKeep.Add(line);
                    }
                }

                if (found)
                {
                    // Overwrite animals.txt with all the lines that were kept
                    File.WriteAllLines(filePath, linesToKeep);
                    deleted = true;
                }
                else
                {
                    MessageBox.Show(animalID + " could not be found in animals.txt.", "Animal Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("animals.txt could not be found, so nothing was deleted.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                MessageBox.Show("animals.txt is open in another program. Close it and try again.", "File In Use", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You do not have permission to change animals.txt (it may be read-only).", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return deleted;
        }

        /// <summary>
        /// Checks if an animal with this ID is already saved in animals.txt.
        /// </summary>
        public bool AnimalIDExists(string animalID)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return false;
                }

                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');

                    // Compare in upper case so wr-0001 and WR-0001 count as the same ID
                    if (parts[0].Trim().ToUpper() == animalID)
                    {
                        return true;
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("animals.txt is open in another program. Close it and try again.", "File In Use", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You do not have permission to read animals.txt.", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        /// <summary>
        /// Adds one new animal as a new line at the end of animals.txt.
        /// The lines already in the file are not changed. Returns true if it was saved.
        /// </summary>
        public bool AddAnimal(Animal animal)
        {
            try
            {
                // If the last line in the file has no line break after it, one must be added first,
                // otherwise the new animal would be joined onto the end of the last line
                bool needsLineBreak = false;

                if (File.Exists(filePath))
                {
                    string existingText = File.ReadAllText(filePath);

                    if (existingText.Length > 0 && !existingText.EndsWith("\n"))
                    {
                        needsLineBreak = true;
                    }
                }

                // true = add to the end of the file instead of overwriting it
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    if (needsLineBreak)
                    {
                        writer.WriteLine();
                    }

                    writer.WriteLine(ToFileLine(animal));
                }

                return true;
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("The folder for animals.txt could not be found, so the animal was not saved.", "Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                MessageBox.Show("animals.txt is open in another program. Close it and try again.", "File In Use", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You do not have permission to change animals.txt (it may be read-only).", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        /// <summary>
        /// Turns an animal into one line for animals.txt in the order
        /// ID|Name|Species|Age|Score|Status|Housing Unit (no spaces around the |).
        /// </summary>
        private string ToFileLine(Animal animal)
        {
            return animal.AnimalID + "|" + animal.Name + "|" + animal.Species + "|" + animal.Age + "|" + animal.RecoveryScore + "|" + animal.Status + "|" + animal.HousingUnit;
        }
    }
}
