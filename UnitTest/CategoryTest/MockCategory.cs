using System;
using System.Collections.Generic;
using System.Data.Common;
using DataAccessLayer;

namespace UnitTest.Category
{
    public class MockCategory: ICategoryContainer, ICategory
    {
        public CategoryDTO Dto;
        public List<CategoryDTO> listDto;
        public List<CategoryDTO> GetAll()
        {
            listDto = new List<CategoryDTO>();
            listDto.Add(
                Dto = new CategoryDTO()
                {
                    ID = 10,
                    Name = "Ipad"
                }
                );
            listDto.Add(
                Dto = new CategoryDTO()
                {
                    ID = 11,
                    Name = "Laptop"
                }
                );
            return listDto;
        }

        public CategoryDTO GetbyId(int id)
        {
            switch (id)
            {
                case 7:
                    Dto = new CategoryDTO()
                    {
                        ID = 7,
                        Name = "pc"
                    };
                    return Dto;

                case 11:
                    Dto = new CategoryDTO()
                    {
                        ID = 7,
                        Name = "pc"
                    };
                    return Dto;
            }

            return new CategoryDTO();
        }

        public void Save(CategoryDTO category)
        {
            Dto = category;
        }
    }
}