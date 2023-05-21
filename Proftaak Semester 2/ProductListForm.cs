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
    public partial class ProductListForm : Form
    {
        ProductContainer container = new ProductContainer();
        public ProductListForm()
        {
            InitializeComponent();
        }



        private void Form3_Load(object sender, EventArgs e)
        {
            
            foreach (Product product in container.Products)
            {
                ListViewItem row = new ListViewItem(new string[]
                {
                    product.ID.ToString(),
                    product.Barcode.ToString(),
                    product.Name,
                    product.Amount.ToString(),
                    product.Location.LocationNumber.ToString(),
                });
                lvwProduct.Items.Add(row);
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

        private void homebtn_Click(object sender, EventArgs e)
        {
            DashboardForm dashboard = new DashboardForm();
            dashboard.Show();
            this.Close();
        }
    }
}
