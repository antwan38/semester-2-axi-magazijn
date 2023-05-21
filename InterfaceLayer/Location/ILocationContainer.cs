using System.Collections.Generic;

namespace DataAccessLayer;

public interface ILocationContainer
{ 
    List<LocationDTO> GetAll();
    LocationDTO GetById(int id);
}