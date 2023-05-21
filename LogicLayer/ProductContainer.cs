using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LogicLayer
{
    public class ProductContainer
    {
        private ProductDAL DAL = new ProductDAL();

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            foreach(ProductDTO dto in DAL.GetAll())
            {
                products.Add(new Product(dto));
            }
            return products;
        }

        public Product Get(int id)
        {
            foreach(Product product in GetAll())
            {
                if (id == product.ID)
                {
                    return product;
                }
            }
            throw new NullReferenceException();
        }

        //outsourced:
        public List<Product> GetListOfProductsOnFilter(string naam, string filterCategorie, string filterBranch)
        {
            return DAL.GetListOfProductsOnFilter(naam, filterCategorie, filterBranch).Select(c => new Product(c)).ToList();
        }
    }
}
