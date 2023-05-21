using DataAccessLayer;
using LogicLayer;
using NUnit.Framework;

namespace UnitTest.Category
{
    [TestFixture]
    public class CategoryTest
    {
        [Test , Category("CategoryTest")]
        public void Save()
        {
            //arrange
            MockCategory mock = new MockCategory();
            CategoryDTO dto = new CategoryDTO()
            {
                ID = 7,
                Name = "phone"
            };
            //act
            LogicLayer.Category category = new LogicLayer.Category(dto.ID, dto.Name, mock);
            category.Save();

            //assert
            Assert.AreEqual(mock.Dto, dto);
        }
    }
}