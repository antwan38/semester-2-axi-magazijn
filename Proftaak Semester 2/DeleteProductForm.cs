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
    public partial class DeleteProductForm : Form
    {
        ProductContainer container = new ProductContainer();
        private string message = "Weet je zeker dat je deze producten wil verwijderen?";
        private string title = "Close window";

        public DeleteProductForm()
        {
            InitializeComponent();

            foreach (Product product in container.Products)
            {
                ListViewItem row = new ListViewItem(new string[]
                {
                    product.ID.ToString(),
                    product.Barcode.ToString(),
                    product.Location.LocationNumber.ToString(),
                    "null"
                });
                lvwProduct.Items.Add(row);
            }
        }

        private void Homebtn_Click(object sender, EventArgs e)
        {
            DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.Show();
            this.Close();
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            //create a messagebox
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, button);

            //if the result is yes the items are deleted
            if (result == DialogResult.Yes)
            {
                foreach (ListViewItem eachItem in lvwProduct.SelectedItems)
                {
                    ProductContainer productContainer = new ProductContainer();
                    productContainer.Delete(eachItem.Text);
                    lvwProduct.Items.Remove(eachItem);
                    
                }
            }
        }

        private void DatabaseLoader(object sender, EventArgs e)
        {
           
        }

    }
}
