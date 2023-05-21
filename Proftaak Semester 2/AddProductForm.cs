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
        public AddProductForm()
        {
            InitializeComponent();
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
            if(tbxName.Text != "" && tbxLocatie.Text != "" && tbxBarcode.Text !="" && nupAmount.Value != 0 && nupCapacity.Value != 0)
            {
                Proftaak_Semester_2.Location location = new Location(0, tbxLocatie.Text, (int)nupCapacity.Value);
                Product product = new Product(0, tbxName.Text, tbxBarcode.Text, (int)nupAmount.Value, location);
                ProductContainer container = new ProductContainer();
                container.Add(product);
                DashboardForm dashboard = new DashboardForm();
                dashboard.Show();
                this.Close();

            }
        }
    }
}
