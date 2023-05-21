using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class CategoryContainer
    {
        private ICategoryContainer _ICatergoryContainer;

        public CategoryContainer(ICategoryContainer iCatergoryContainer)
        {
            _ICatergoryContainer = iCatergoryContainer;
        }

        public List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();
            foreach (CategoryDTO dto in _ICatergoryContainer.GetAll())
            {
                categories.Add(new Category(dto));
            }

            return categories;
        }

        public Category Get(int id)
        {
            CategoryDTO dto = _ICatergoryContainer.GetbyId(id);
            Category category = new Category(dto);
            if (id == category.ID)
            {
                return category;
            }

            throw new NullReferenceException("Given ID isn't present in DAL.");
        }
    }
}