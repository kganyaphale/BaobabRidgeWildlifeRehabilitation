using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    /// <summary>
    /// The main screen of the program: the animal grid, the Add/Update inputs,
    /// the Delete button and the Summary Report.
    /// </summary>
    public partial class MainForm : Form
    {
        private FileHandler fileHandler = new FileHandler();

        /// <summary>
        /// Creates the main form and connects the Load event.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        /// <summary>
        /// Shows all the animals from animals.txt in the grid when the program starts.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        /// <summary>
        /// Reloads the grid with the latest animal records from animals.txt
        /// and gives the columns readable headers.
        /// </summary>
        public void RefreshGrid()
        {
            List<Animal> animalList = fileHandler.LoadAnimals();

            // Clear existing bindings
            dgvAnimals.DataSource = null;
            dgvAnimals.DataSource = animalList;

            if (dgvAnimals.Columns.Count > 0)
            {
                dgvAnimals.Columns["AnimalID"].HeaderText = "Animal ID";
                dgvAnimals.Columns["RecoveryScore"].HeaderText = "Recovery Score";
                dgvAnimals.Columns["HousingUnit"].HeaderText = "Housing Unit";
            }
        }

        /// <summary>
        /// Deletes the animal selected in the grid after the user confirms with Yes.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // A row must be selected before anything can be deleted
            if (dgvAnimals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an animal in the grid first.", "No Animal Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Read the ID and name from the selected row for the confirmation message
            string animalID = dgvAnimals.SelectedRows[0].Cells["AnimalID"].Value.ToString();
            string animalName = dgvAnimals.SelectedRows[0].Cells["Name"].Value.ToString();

            DialogResult answer = MessageBox.Show("Delete " + animalID + " (" + animalName + ")? This cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Choosing No changes nothing
            if (answer == DialogResult.Yes)
            {
                bool deleted = fileHandler.DeleteAnimal(animalID);

                if (deleted)
                {
                    RefreshGrid();

                    // If the deleted animal was loaded in the input boxes, clear them
                    if (txtAnimalID.ReadOnly && txtAnimalID.Text == animalID)
                    {
                        ClearInputs();
                        SetEditMode(false);
                    }
                }
            }
        }

        /// <summary>
        /// Adds a new animal from the input boxes to animals.txt after all the inputs are valid.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // true = also check that the ID is not already used
            if (!ValidateInputs(true))
            {
                return;
            }

            Animal newAnimal = ReadAnimalFromInputs();

            // The single classification method works out the status and housing unit
            newAnimal.DetermineStatusAndHousing();

            bool saved = fileHandler.AddAnimal(newAnimal);

            if (saved)
            {
                MessageBox.Show("Animal added successfully.\n\nStatus: " + newAnimal.Status + "\nHousing Unit: " + newAnimal.HousingUnit, "Animal Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
                ClearInputs();
            }
        }

        /// <summary>
        /// Checks every input box against the validation rules.
        /// If an input is wrong it shows a message, puts the cursor in that box and returns false.
        /// checkIDIsNew is true when adding (the ID may not exist yet) and false when updating.
        /// </summary>
        private bool ValidateInputs(bool checkIDIsNew)
        {
            // Trim removes spaces before and after, ToUpper turns wr-0007 into WR-0007
            string id = txtAnimalID.Text.Trim().ToUpper();
            string name = txtName.Text.Trim();
            string species = txtSpecies.Text.Trim();
            int age;
            int recoveryScore;

            if (id == "")
            {
                ShowInputError("Please enter an Animal ID.", txtAnimalID);
                return false;
            }

            if (!IsValidAnimalID(id))
            {
                ShowInputError("Animal ID must be WR- followed by exactly 4 digits (for example WR-0007).", txtAnimalID);
                return false;
            }

            if (checkIDIsNew && fileHandler.AnimalIDExists(id))
            {
                ShowInputError("Animal ID " + id + " already exists. Please use a different ID.", txtAnimalID);
                return false;
            }

            if (name == "" || name.Length > 30)
            {
                ShowInputError("Name must be between 1 and 30 characters.", txtName);
                return false;
            }

            if (name.Contains("|"))
            {
                ShowInputError("Name cannot contain the | character.", txtName);
                return false;
            }

            if (species == "" || species.Length > 30)
            {
                ShowInputError("Species must be between 1 and 30 characters.", txtSpecies);
                return false;
            }

            if (species.Contains("|"))
            {
                ShowInputError("Species cannot contain the | character.", txtSpecies);
                return false;
            }

            // TryParse fails for text and decimals, so only whole numbers get through
            if (!int.TryParse(txtAge.Text.Trim(), out age) || age < 0 || age > 100)
            {
                ShowInputError("Age must be a whole number between 0 and 100.", txtAge);
                return false;
            }

            if (!int.TryParse(txtRecoveryScore.Text.Trim(), out recoveryScore) || recoveryScore < 0 || recoveryScore > 100)
            {
                ShowInputError("Recovery Score must be a whole number between 0 and 100.", txtRecoveryScore);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns true if the ID is WR- followed by exactly 4 digits, for example WR-0007.
        /// </summary>
        private bool IsValidAnimalID(string id)
        {
            if (id.Length != 7 || !id.StartsWith("WR-"))
            {
                return false;
            }

            // Characters 3 to 6 are the 4 characters after "WR-" and must all be digits
            for (int i = 3; i < 7; i++)
            {
                if (!char.IsDigit(id[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Shows a validation message and puts the cursor back in the box that has the problem.
        /// </summary>
        private void ShowInputError(string message, TextBox box)
        {
            MessageBox.Show(message, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            box.Focus();
            box.SelectAll();
        }

        /// <summary>
        /// Creates an Animal object from the input boxes. Only call this after ValidateInputs returned true.
        /// </summary>
        private Animal ReadAnimalFromInputs()
        {
            Animal animal = new Animal();
            animal.AnimalID = txtAnimalID.Text.Trim().ToUpper();
            animal.Name = txtName.Text.Trim();
            animal.Species = txtSpecies.Text.Trim();
            animal.Age = int.Parse(txtAge.Text.Trim());
            animal.RecoveryScore = int.Parse(txtRecoveryScore.Text.Trim());
            return animal;
        }

        /// <summary>
        /// Empties all the input boxes so the next animal can be entered.
        /// </summary>
        private void ClearInputs()
        {
            txtAnimalID.Clear();
            txtName.Clear();
            txtSpecies.Clear();
            txtAge.Clear();
            txtRecoveryScore.Clear();
            txtAnimalID.Focus();
        }

        /// <summary>
        /// Loads the animal in the clicked grid row into the input boxes so it can be edited.
        /// </summary>
        private void dgvAnimals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Clicking a column header gives a row index of -1, so that is ignored
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvAnimals.Rows[e.RowIndex];

            Animal animal = new Animal();
            animal.AnimalID = row.Cells["AnimalID"].Value.ToString();
            animal.Name = row.Cells["Name"].Value.ToString();
            animal.Species = row.Cells["Species"].Value.ToString();
            animal.Age = int.Parse(row.Cells["Age"].Value.ToString());
            animal.RecoveryScore = int.Parse(row.Cells["RecoveryScore"].Value.ToString());

            LoadAnimalIntoInputs(animal);
        }

        /// <summary>
        /// Finds the animal with the ID typed in the search box (not case-sensitive) and loads it for editing.
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchID = txtSearchID.Text.Trim().ToUpper();

            if (searchID == "")
            {
                MessageBox.Show("Please type an Animal ID to search for.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearchID.Focus();
                return;
            }

            List<Animal> animals = fileHandler.LoadAnimals();

            foreach (Animal animal in animals)
            {
                // Both IDs are in upper case, so wr-0001 finds WR-0001
                if (animal.AnimalID.ToUpper() == searchID)
                {
                    LoadAnimalIntoInputs(animal);
                    return;
                }
            }

            // Not found: tell the user and change nothing else
            MessageBox.Show("No animal with the ID " + searchID + " was found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Saves the changes to the loaded animal after checking all the inputs again.
        /// </summary>
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            // false = the ID is not checked for being new, because an existing animal's ID cannot change
            if (!ValidateInputs(false))
            {
                return;
            }

            Animal updatedAnimal = ReadAnimalFromInputs();

            // Always recalculate, even if the score was not changed
            updatedAnimal.DetermineStatusAndHousing();

            bool saved = fileHandler.UpdateAnimal(updatedAnimal);

            if (saved)
            {
                MessageBox.Show(updatedAnimal.AnimalID + " was updated.\n\nStatus: " + updatedAnimal.Status + "\nHousing Unit: " + updatedAnimal.HousingUnit, "Animal Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
                ClearInputs();
                SetEditMode(false);
            }
        }

        /// <summary>
        /// Leaves edit mode and empties the input boxes so a new animal can be added.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
            SetEditMode(false);
        }

        /// <summary>
        /// Puts an animal's details into the input boxes and switches the form to edit mode.
        /// </summary>
        private void LoadAnimalIntoInputs(Animal animal)
        {
            txtAnimalID.Text = animal.AnimalID;
            txtName.Text = animal.Name;
            txtSpecies.Text = animal.Species;
            txtAge.Text = animal.Age.ToString();
            txtRecoveryScore.Text = animal.RecoveryScore.ToString();

            SetEditMode(true);
        }

        /// <summary>
        /// Switches between Add mode (editing = false) and Edit mode (editing = true).
        /// In Edit mode the ID cannot be changed, Add is disabled and Save Changes is enabled.
        /// </summary>
        private void SetEditMode(bool editing)
        {
            txtAnimalID.ReadOnly = editing;
            btnAdd.Enabled = !editing;
            btnSaveChanges.Enabled = editing;
        }

        /// <summary>
        /// Works out the summary from the animals currently in animals.txt and shows it on the form.
        /// </summary>
        private void btnGenerateSummary_Click(object sender, EventArgs e)
        {
            // Load from the file so the summary always uses the latest data
            List<Animal> animals = fileHandler.LoadAnimals();

            SummaryReport report = new SummaryReport();
            report.Calculate(animals);

            lblTotalAnimals.Text = report.TotalAnimals.ToString();
            lblAverageAge.Text = report.FormatAverage(report.AverageAge);
            lblAverageScore.Text = report.FormatAverage(report.AverageScore);
            lblCriticalCount.Text = report.CriticalCount.ToString();
            lblSeriousCount.Text = report.SeriousCount.ToString();
            lblStableCount.Text = report.StableCount.ToString();
            lblRecoveringCount.Text = report.RecoveringCount.ToString();
            lblReleaseReadyCount.Text = report.ReleaseReadyCount.ToString();

            // Save the same results to summary.txt
            bool saved = report.SaveToFile();

            if (saved)
            {
                MessageBox.Show("The summary was saved to summary.txt.", "Summary Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
