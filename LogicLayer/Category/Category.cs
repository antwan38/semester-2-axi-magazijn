using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Category
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        private ICategory _ICatergory;

        public Category(int id, string name, ICategory icatergory)
        {
            ID = id;
            Name = name;
            _ICatergory = icatergory;

        }

        public Category(string name, ICategory icatergory)
        {
            Name = name;
            _ICatergory = icatergory;
        }

        public Category(CategoryDTO dto)
        {
            ID = dto.ID;
            Name = dto.Name;
        }

        public void Save()
        {
            _ICatergory.Save(ToDTO());
        }

        private CategoryDTO ToDTO()
        {
            return new CategoryDTO { 
                ID = this.ID,
                Name = this.Name
            };
        }
    }
}
