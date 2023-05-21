using System.Collections.Generic;
using DataAccessLayer;
using LogicLayer;
using NUnit.Framework;

namespace UnitTest.LocationTest
{
    [TestFixture]
    public class LocationContainerTest
    {
        [Test, Category("LocationTest")]
        public void GetAll()
        {
            //Arrange
            LocationMock mock = new LocationMock();
            LocationContainer container = new LocationContainer(mock);
            LocationDTO dto;
            Branch branch = new Branch(12, "Tilburg", "Prof. goosselenlaan", "12", "5308Kl");
            BranchDTO branchDto = branch.ToDTO();
            List<LocationDTO> Listdto = new List<LocationDTO>();
            Listdto.Add(
                dto = new LocationDTO()
                {
                    ID = 14,
                    LocationNumber = "12",
                    Branch = branchDto,
                    MaxCapacity = 120
                }
            );
            Listdto.Add(
                dto = new LocationDTO()
                {
                    ID = 21,
                    LocationNumber = "17",
                    Branch = branchDto,
                    MaxCapacity = 300
                }
            );

            //act
            container.GetAll();

            //assert
            CollectionAssert.AreEquivalent(mock.Dtos, Listdto);
        }

        [Test, Category("LocationTest")]
        public void GetById()
        {
            //arrange
            LocationMock mock = new LocationMock();
            LocationContainer locationContainer = new LocationContainer(mock);
            int id = 14;
            Branch ExpectedBranch = new Branch(12, "Tilburg", "Prof. goosselenlaan", "12", "5308Kl");
            BranchDTO ExpectedBranchDto = ExpectedBranch.ToDTO();
            LocationDTO ExpectedDto = new LocationDTO()
            {
                ID = 14,
                LocationNumber = "12",
                Branch = ExpectedBranchDto,
                MaxCapacity = 120
            };
            
            //act
            locationContainer.Get(id);

            //assert
            Assert.AreEqual(ExpectedDto.ID, mock.dto.ID);
            Assert.AreEqual(ExpectedDto.LocationNumber, mock.dto.LocationNumber);
            Assert.AreEqual(ExpectedDto.MaxCapacity, mock.dto.MaxCapacity);
            Assert.AreEqual(ExpectedDto.Branch.ID, mock.dto.Branch.ID);
        }
    }
}