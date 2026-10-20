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
    public partial class Form1 : Form
    {
        private FileHandler fileHandler = new FileHandler();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Display records on startup
            RefreshGrid();
        }
        /// <summary>
        /// Reloads the DataGridView with the latest animal records from the text file.
        /// Formats the UI columns to fit the screen automatically and enforces read-only status.
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
                }
            }
        }

        private void btnAddAnimal_Click(object sender, EventArgs e)
        {
            AddAnimalForm addForm = new AddAnimalForm(this);
            addForm.Show();
        }
    }
}
