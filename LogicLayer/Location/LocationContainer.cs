using DataAccessLayer;
using System;
using System.Collections.Generic;
namespace LogicLayer
{
    public class LocationContainer
    {
        private ILocationContainer _iLocationContainer;

        public LocationContainer(ILocationContainer iLocationContainer)
        {
            _iLocationContainer = iLocationContainer;
        }

        public List<Location> GetAll()
        {
            List<Location> locations = new List<Location>();
            foreach (LocationDTO dto in _iLocationContainer.GetAll())
            {
                locations.Add(new Location(dto));
            }
            return locations;
        }

        public Location Get(int id)
        {
            LocationDTO dto = _iLocationContainer.GetById(id);
            Location location = new Location(dto);
            if (dto.ID == id)
            {
                return location;
            }
            
            throw new NullReferenceException("Given ID isn't present in DAL.");
        }
    }
}
