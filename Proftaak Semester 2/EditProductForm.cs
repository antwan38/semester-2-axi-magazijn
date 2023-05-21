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
    public partial class EditProductForm : Form
    {
        ProductContainer container = new ProductContainer();
        public EditProductForm()
        {
            InitializeComponent();
            foreach (Product product in container.Products)
            {
                cmbNaam1.Items.Add($"{product.Name} ({product.ID})");
                cmbNaam2.Items.Add($"{product.Name} ({product.ID})");
                cmbNaam3.Items.Add($"{product.Name} ({product.ID})");
                cmbNaam4.Items.Add($"{product.Name} ({product.ID})");
                cmbNaam5.Items.Add($"{product.Name} ({product.ID})");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DashboardForm dashboard = new DashboardForm();
            dashboard.Show();
            this.Close();
        }

        private void btnWijzig_Click(object sender, EventArgs e)
        {
            if (cbxPlusOfMin.SelectedIndex > -1)
            {
                foreach (Product product in GetSelected())
                {
                    int newAmount;
                    if (cbxPlusOfMin.Text == "+")
                        newAmount = product.Amount + Convert.ToInt32(nudAantal.Value);
                    else
                        newAmount = product.Amount - Convert.ToInt32(nudAantal.Value);

                    if (newAmount < 0)
                        newAmount = 0;

                    Product editedProduct = new Product(
                            product.ID,
                            product.Name,
                            product.Barcode,
                            newAmount,
                            product.Location
                            );
                    container.Edit(editedProduct);
                }
            }
        }

        private List<Product> GetSelected()
        {
            if (cmbNaam1.SelectedIndex > -1 && cmbNaam2.SelectedIndex > -1 && cmbNaam3.SelectedIndex > -1
                && cmbNaam4.SelectedIndex > -1 && cmbNaam5.SelectedIndex > -1)
            {
                List<Product> selectedProducts = new List<Product>()
                {
                container.Get(Convert.ToInt32(cmbNaam1.SelectedItem.ToString().Split('(', ')')[1])),
                container.Get(Convert.ToInt32(cmbNaam2.SelectedItem.ToString().Split('(', ')')[1])),
                container.Get(Convert.ToInt32(cmbNaam3.SelectedItem.ToString().Split('(', ')')[1])),
                container.Get(Convert.ToInt32(cmbNaam4.SelectedItem.ToString().Split('(', ')')[1])),
                container.Get(Convert.ToInt32(cmbNaam5.SelectedItem.ToString().Split('(', ')')[1])),
                };
                return selectedProducts;
            }
            else
                MessageBox.Show("Not all comboboxes are selected. Returning null.");
            return null;
        }
    }
}
