using System;
using System.Collections.Generic;
using DataAccessLayer;
using LogicLayer;
using NUnit.Framework;

namespace UnitTest.Category
{
    [TestFixture]
    public class CategoryContainerTest
    {
        [Test, Category("CategoryTest")]
        public void GetAll()
        {
            //arrange
            List<CategoryDTO> dtos = new List<CategoryDTO>();
            MockCategory mock = new MockCategory();
            CategoryContainer container = new CategoryContainer(mock);
            dtos = new List<CategoryDTO>();
            dtos.Add(
                new CategoryDTO()
                {
                    ID = 10,
                    Name = "Ipad"
                }
            );
            dtos.Add(
                new CategoryDTO()
                {
                    ID = 11,
                    Name = "Laptop"
                }
            );
            
            //act
            container.GetAll();
            
            //assert
            CollectionAssert.AreEquivalent(mock.listDto, dtos);
        }
        
        [Test , Category("CategoryTest")]
        public void GetById()
        {
            //arrange 
            MockCategory mock = new MockCategory();
            CategoryContainer container = new CategoryContainer(mock);
            CategoryDTO dto = new CategoryDTO()
            {
                ID = 7,
                Name = "pc"
            };
            LogicLayer.Category category = new LogicLayer.Category(dto);

            //act
            container.Get(dto.ID);

                //assert
            Assert.AreEqual(mock.Dto, dto);
        }
        
        [Test, Category("CategoryTest")]
        public void GetByIdFail()
        {
            //arrange 
            MockCategory mock = new MockCategory();
            CategoryContainer container = new CategoryContainer(mock);
            CategoryDTO dto = new CategoryDTO()
            {
                ID = 9,
                Name = "pc"
            };
            LogicLayer.Category category = new LogicLayer.Category(dto);

            //act
            try
            {
                container.Get(dto.ID);
            }

            //assert
            catch (NullReferenceException)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
    }
}