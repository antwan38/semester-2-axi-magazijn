using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proftaak_Semester_2
{
    public partial class AddProductForm : Form
    {
        private LocationContainer locationContainer = new LocationContainer();
        private CategoryContainer categoryContainer = new CategoryContainer();
        public AddProductForm()
        {
            InitializeComponent();

            foreach (Location location in locationContainer.Locations)
            {
                cbxLocatie.Items.Add($"{location.LocationNumber} ({location.ID})");
            }

            foreach (Category category in categoryContainer.Categories)
            {
                cmbCategory.Items.Add($"{category.Name} ({category.ID})");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DashboardForm dashboard = new DashboardForm();
            dashboard.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnToevoegen_Click(object sender, EventArgs e)
        {
            if (tbxName.Text != "" && cbxLocatie.Text != "" && tbxBarcode.Text != "" && nupAmount.Value != 0)
            {
                LogicLayer.Location location = new Location(Convert.ToInt32(cbxLocatie.Text.Split('(', ')')[1]), cbxLocatie.Text, (int)nupCapacity.Value);
                Category category = new Category(Convert.ToInt32(cmbCategory.Text.Split('(', ')')[1]), cmbCategory.Text);
                Product product = new Product(0, tbxName.Text, tbxBarcode.Text, (int)nupAmount.Value, location, category);

                product.Save();

                DashboardForm dashboard = new DashboardForm();
                dashboard.Show();
                this.Close();

            }
        }

        private void btnLocatieToevoegen_Click(object sender, EventArgs e)
        {
            if (tbxLocatieNummer.Text != "" && nupCapacity.Value != 0)
            {
                LogicLayer.Location location = new Location(0, tbxLocatieNummer.Text, (int)nupCapacity.Value);

                location.Save();


                DashboardForm dashboard = new DashboardForm();
                dashboard.Show();
                this.Close();

            }

        }
    }
}
