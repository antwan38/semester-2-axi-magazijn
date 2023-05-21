using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proftaak_Semester_2
{
    public class ProductContainer
    {
        private DatabaseClass database = new DatabaseClass("SELECT * FROM Product");
        public List<Product> Products { get; private set; }

        public ProductContainer()
        {
            Products = database.GetAllProducts();
        }

        public void Add(Product product)
        {
            Products.Add(product);
            DatabaseClass databaseClass = new DatabaseClass($"INSERT into Product (Barcode, Naam, Aantal, LocatieID, CategorieID) values ('{product.Barcode}', '{product.Name}', {product.Amount.ToString()}, 1, 1);");
            databaseClass.Add(product);

           // to-do add to database using Database Class
        }

        public void Edit(Product product)
        {
            database.Edit(product);
        }

        public Product Get(int id)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].ID == id)
                {
                    return Products[i];
                }
            }
            MessageBox.Show($"Couldn't find product with ID {id}. Returning null.");
            return null;
        }

        public void Delete(string ID)
        {
            database.Delete(ID);
        }
    }
}
