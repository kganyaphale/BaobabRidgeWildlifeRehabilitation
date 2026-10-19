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
    }
}
