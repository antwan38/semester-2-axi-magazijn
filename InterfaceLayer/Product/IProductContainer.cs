using System.Collections.Generic;

namespace DataAccessLayer;

public interface IProductContainer
{
    List<ProductDTO> GetListOfProductsOnFilter(string naam, string filterCategorie, string filterBranch); 
    List<ProductDTO> GetAll();
}