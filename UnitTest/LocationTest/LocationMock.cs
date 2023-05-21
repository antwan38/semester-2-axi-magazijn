using System.Collections.Generic;
using DataAccessLayer;
using LogicLayer;
using NUnit.Framework;

namespace UnitTest.LocationTest
{
    public class LocationMock: ILocation, ILocationContainer
    {
        public LocationDTO dto;
        public List<LocationDTO> Dtos;
        public void Save(LocationDTO location)
        {
            dto = location;
        }

        public List<LocationDTO> GetAll()
        {
            Dtos = new List<LocationDTO>();
            Branch branch = new Branch(12, "Tilburg", "Prof. goosselenlaan", "12", "5308Kl");
            BranchDTO branchDto = branch.ToDTO();
            Dtos.Add(
                dto = new LocationDTO()
                {
                    ID = 14,
                    LocationNumber = "12",
                    Branch = branchDto,
                    MaxCapacity = 120
                }
            );
            Dtos.Add(
                dto = new LocationDTO()
                {
                    ID = 21,
                    LocationNumber = "17",
                    Branch = branchDto,
                    MaxCapacity = 300
                }
            );
            return Dtos;
        }
        
        public LocationDTO GetById(int id)
        {
            Branch branch = new Branch(12, "Tilburg", "Prof. goosselenlaan", "12", "5308Kl");
            BranchDTO branchDto = branch.ToDTO();
            switch (id)
            {
                case 14:
                    dto = new LocationDTO()
                    {
                        ID = 14,
                        LocationNumber = "12",
                        Branch = branchDto,
                        MaxCapacity = 120
                    };
                    break;
                case 17:
                    dto = new LocationDTO()
                    {
                        ID = 17,
                        LocationNumber = "21",
                        Branch = branchDto,
                        MaxCapacity = 200
                    };
                    break;
            }

            return dto;
        }
    }
}