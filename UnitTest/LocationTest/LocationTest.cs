using DataAccessLayer;
using NUnit.Framework;
using LogicLayer;

namespace UnitTest.LocationTest
{
    [TestFixture]
    public class LocationTest
    {
        [Test, Category("LocationTest")]
        public void save()
        {
            //arrange
            LocationMock mock = new LocationMock();
            Branch branch = new Branch(12, "Tilburg", "Prof. goosselenlaan", "12", "5308Kl");
            LocationDTO locationDto = new LocationDTO()
            {
                ID = 14,
                LocationNumber = "12",
                MaxCapacity = 120,
                Branch = branch.ToDTO()
            };
            Location location = new Location(locationDto.ID, locationDto.LocationNumber, locationDto.MaxCapacity, branch, mock);
            
            //act
            location.Save();
            
            //arrange
            Assert.AreEqual(mock.dto, locationDto);
        }
    }
}