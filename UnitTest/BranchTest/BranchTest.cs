using System;
using DataAccessLayer;
using LogicLayer;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class BranchTest
    {
        [Test , Category("BranchTest")]
        public void Save()
        {
            //Arrange
            BranchMock mock = new BranchMock();
            BranchDTO dto = new BranchDTO()
            {
                PlaceName = "Dongen",
                StreetName = "TramStraat",
                HouseNumber = "12",
                PostalCode = "5103CE"
            };

            //act
            Branch branch =
                new Branch(dto.PlaceName, dto.StreetName, dto.HouseNumber, dto.PostalCode, mock);
            branch.Save();

            //assert
            Assert.AreEqual(mock.MockBranchDto, dto);
        }
    }
}