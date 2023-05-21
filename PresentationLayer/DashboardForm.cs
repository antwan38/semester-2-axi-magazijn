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
    public partial class DashboardForm : Form
    {

        public DashboardForm()
        {
            InitializeComponent();
        }

        private void btnProductenlijst_Click(object sender, EventArgs e)
        {
            ProductListForm productList = new ProductListForm();
            this.Hide();
            productList.Show();
        }

        private void btnAantalveranderen_Click(object sender, EventArgs e)
        {
            EditProductForm editProduct = new EditProductForm();
            this.Hide();
            editProduct.Show();
        }

        private void btnProductinfo_Click(object sender, EventArgs e)
        {
            DeleteProductForm deleteProduct = new DeleteProductForm();
            this.Hide();
            deleteProduct.Show();
        }

        private void btnNieuwproduct_Click(object sender, EventArgs e)
        {
            AddProductForm addProduct = new AddProductForm();
            this.Hide();
            addProduct.Show();
        }
    }
}
