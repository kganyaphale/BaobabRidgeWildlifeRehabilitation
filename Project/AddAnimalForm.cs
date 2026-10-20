using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;

namespace Project
{
    public partial class AddAnimalForm : Form
    {

        private Form1 mainform;

        public AddAnimalForm(Form1 form)
        {
            InitializeComponent();

            mainform = form;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddAnimal_Click(object sender, EventArgs e)
        {
            string id = txtAnimalID.Text.Trim().ToUpper();
            string name = txtName.Text.Trim();
            string species = txtSpecies.Text.Trim();
            int age;
            int recoveryScore;

            if (id == "")
            {
                MessageBox.Show("Please enter an ID for your animal.");
                txtAnimalID.Focus(); //returns user back to entering ID if it's empty
                return;
            }

            if (id.Length != 7)
            {
                MessageBox.Show("Animal ID must be in the format WR-0000.");
                txtAnimalID.Focus();
                return;
            }

            if (!id.StartsWith("WR-"))
            {
                MessageBox.Show("Animal ID must start with WR-.");
                txtAnimalID.Focus();
                return;
            }

            if (AnimalIDExists(id))
            {
                MessageBox.Show("Animal ID already exists.");
                txtAnimalID.Focus();
                return;
            }


            if (name == "")
            {
                MessageBox.Show("Please enter a name.");
                txtName.Focus();
                return;
            }

            if (name.Length > 30)
            {
                MessageBox.Show("Animal name is too long.");
                txtName.Focus();
                return;
            }

            if (name.Contains("|"))
            {
                MessageBox.Show("Name cannot contain the '|' character.");
                txtName.Focus();
                return;
            }


            if (species == "")
            {
                MessageBox.Show("Please enter a species.");
                txtSpecies.Focus();
                return;
            }

            if (species.Length > 30)
            {
                MessageBox.Show("Species type is too long.");
                txtSpecies.Focus();
                return;
            }

            if (species.Contains("|"))
            {
                MessageBox.Show("Species cannot contain the '|' character.");
                txtSpecies.Focus();
                return;
            }

            if (txtAge.Text.Trim() == "")
            {
                MessageBox.Show("Please enter an age.");
                txtAge.Focus();
                return;
            }

            if (!int.TryParse(txtAge.Text.Trim(), out age))
            {
                MessageBox.Show("Age must be a whole number.");
                txtAge.Focus();
                return;
            }

            if (age < 0 || age > 100)
            {
                MessageBox.Show("Please enter an age between 0-100.");
                txtAge.Focus();
                return;
            }


            if (txtRecoveryScore.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the score.");
                txtRecoveryScore.Focus();
                return;
            }

            if (!int.TryParse(txtRecoveryScore.Text.Trim(), out recoveryScore))
            {
                MessageBox.Show("Recovery score must be a whole number.");
                txtRecoveryScore.Focus();
                return;
            }

            if (recoveryScore < 0 || recoveryScore > 100)
            {
                MessageBox.Show("Please enter a score between 0-100.");
                txtRecoveryScore.Focus();
                return;
            }

            string status = "";
            string housingUnit = "";
            ClassifyAnimal(recoveryScore, ref status, ref housingUnit); // take recoveryScore, send it to classification method and let method fill status and housing unit 

            SaveAnimal(
                id,
                name,
                species,
                age,
                recoveryScore,
                status,
                housingUnit);

            MessageBox.Show(
                "Animal added successfully.\n" +
                "Status: " + status + "\n" +
                "Housing Unit: " + housingUnit);

            ClearControls();
        }

        private bool AnimalIDExists(string id)
        {
            if (!File.Exists("animals.txt"))
            {
                return false;
            }

            string[] animals = File.ReadAllLines("animals.txt");

            foreach (string animal in animals)
            {
                string[] details = animal.Split('|');

                if (details.Length > 0)
                {
                    if (details[0] == id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
        private void ClassifyAnimal(int recoveryScore, ref string status, ref string housingUnit)
        {
            if (recoveryScore >=0 && recoveryScore <= 19)
            {
                status = "Critical";
                housingUnit = "Intensive Care Unit"; 
            }
            else if (recoveryScore >=20 && recoveryScore <=39)
            {
                status = "Serious";
                housingUnit = "High-Dependency Ward";
            }
            else if (recoveryScore >= 40 && recoveryScore <= 59)
            {
                status = "Stable";
                housingUnit = "Recovery Ward";
            }
            else if (recoveryScore >= 60 && recoveryScore <= 79)
            {
                status = "Recovering";
                housingUnit = "Outdoor Enclosure";
            }
            else if (recoveryScore >= 80 && recoveryScore <= 100)
            {
                status = "Release-Ready";
                housingUnit = "Pre-Release Camp";
            }
        }

        private void SaveAnimal(
            string id,
            string name,
            string species,
            int age,
            int recoveryScore,
            string status,
            string housingUnit)
        {
            using (StreamWriter writer = new StreamWriter("animals.txt", true))
            {
                writer.WriteLine(
                    id + " |" +
                    name + " |" +
                    species + " |" +
                    age + " |" +
                    recoveryScore + " |" +
                    status + " |" +
                    housingUnit);
            }
        }

        private void ClearControls()
        {
            txtAnimalID.Clear();
            txtName.Clear();
            txtSpecies.Clear();
            txtAge.Clear();
            txtRecoveryScore.Clear();

            txtAnimalID.Focus();
        }
    }
}
