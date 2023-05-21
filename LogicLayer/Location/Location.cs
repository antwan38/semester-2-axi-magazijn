using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace LogicLayer
{
    public class Location
    {
        public int ID { get; private set; }
        public string LocationNumber { get; private set; }
        public int MaxCapacity {get; private set; }
        public Branch Branch { get; private set; }

        private ILocation _ILocation;


        public Location(int id, string locationNumber, int maxCapacity, Branch branch, ILocation iLocation)
        {
            ID = id;
            LocationNumber = locationNumber;
            MaxCapacity = maxCapacity;
            Branch = branch;
            _ILocation = iLocation;
        }

        public Location(string locationNumber, int maxCapacity, Branch branch, ILocation iLocation)
        {
            LocationNumber = locationNumber;
            MaxCapacity = maxCapacity;
            Branch = branch;
            _ILocation = iLocation;
        }

        public Location(LocationDTO dto)
        {
            ID = dto.ID;
            LocationNumber = dto.LocationNumber;
            MaxCapacity = dto.MaxCapacity;
            Branch = new Branch(dto.Branch);
        }

       public void Save()
        {
            LocationDAL dal = new LocationDAL();
            _ILocation.Save(ToDTO());
        }


        private LocationDTO ToDTO()
        {
            return new LocationDTO
            {
                ID = this.ID,
                LocationNumber = this.LocationNumber,
                MaxCapacity = this.MaxCapacity,
                Branch = Branch.ToDTO()
            };
        }

    }
    
}
