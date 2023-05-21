using System;
using System.Collections.Generic;
using DataAccessLayer;
using LogicLayer;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class BranchContainerTest
    {
        
        public List<BranchDTO> DtoList = new List<BranchDTO>();
        public BranchDTO dto;
        
        [Test, Category("BranchTest")]
        public void GetAll()
        {
            BranchMock mock = new BranchMock();
            BranchContainer container = new BranchContainer(mock);
            //arrange
            DtoList.Add(
                dto = new BranchDTO()
                {
                    PlaceName = "Dongen",
                    StreetName = "TramStraat",
                    HouseNumber = "12",
                    PostalCode = "5103CE"
                }
            );
            
            DtoList.Add(
                dto = new BranchDTO()
                {
                    PlaceName = "Tilburg",
                    StreetName = "prof. goossenlaan",
                    HouseNumber = "1",
                    PostalCode = "5103SR"
                }
            );
            
            //act
            container.GetAll();
            
            //assert
             CollectionAssert.AreEquivalent(mock.MockBranchDtos, DtoList);
        }

        [Test , Category("BranchTest")]
        public void GetValid()
        {
            //arrange
            BranchMock mock = new BranchMock();
            BranchContainer container = new BranchContainer(mock);
            dto = new BranchDTO()
            {
                ID = 7,
                PlaceName = "Dongen",
                StreetName = "TramStraat",
                HouseNumber = "12",
                PostalCode = "5103CE"
            };
            int id = 7;
            
            //act
            container.Get(id);

            //assert
            Assert.AreEqual(mock.MockBranchDto, dto);
        }
        
        [Test , Category("BranchTest")]
        public void GetInvalid()
        {
            //arrange
            BranchMock mock = new BranchMock();
            BranchContainer container = new BranchContainer(mock);
            dto = new BranchDTO()
            {
                ID = 9,
                PlaceName = "Dongen",
                StreetName = "TramStraat",
                HouseNumber = "12",
                PostalCode = "5103CE"
            };
            int id = 9;
            
            //act
            try
            {
                container.Get(id);
            }

            //assert
            catch (NullReferenceException)
            {
                Assert.Pass();
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}

