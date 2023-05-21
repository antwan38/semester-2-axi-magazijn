using System.Collections.Generic;

namespace DataAccessLayer;

public interface ICategoryContainer
{ 
    List<CategoryDTO> GetAll(); 
    CategoryDTO GetbyId(int id);
}