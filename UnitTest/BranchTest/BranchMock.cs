using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLayer;

namespace UnitTest
{
    public class BranchMock : IBranch, IBranchContainer

    {
    public BranchDTO MockBranchDto;
    public List<BranchDTO> MockBranchDtos;

    public int Save(BranchDTO branch)
    {
        MockBranchDto = branch;
        return 1;
    }

    public List<BranchDTO> GetAll()
    {
        MockBranchDtos = new List<BranchDTO>();
        MockBranchDtos.Add(
            MockBranchDto = new BranchDTO()
            {
                PlaceName = "Dongen",
                StreetName = "TramStraat",
                HouseNumber = "12",
                PostalCode = "5103CE"
            }
        );

        MockBranchDtos.Add(
            MockBranchDto = new BranchDTO()
            {
                PlaceName = "Tilburg",
                StreetName = "prof. goossenlaan",
                HouseNumber = "1",
                PostalCode = "5103SR"
            }
        );

        return MockBranchDtos;
    }

    public BranchDTO Get(int id)
    {
        switch (id)
        {
            case 7:
                MockBranchDto = new BranchDTO()
                {
                    ID = 7,
                    PlaceName = "Dongen",
                    StreetName = "TramStraat",
                    HouseNumber = "12",
                    PostalCode = "5103CE"
                };
                break;
            case 10:
                MockBranchDto = new BranchDTO()
                {
                    ID = 10,
                    PlaceName = "Tilburg",
                    StreetName = "prof. goossenlaan",
                    HouseNumber = "1",
                    PostalCode = "5103SR"
                };
                break;
        }
        return MockBranchDto;
    }
    }
}

