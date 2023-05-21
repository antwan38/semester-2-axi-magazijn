using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_Semester_2
{
    public class Location
    {
        public int ID { get; private set; }
        public string LocationNumber { get; private set; }

        public int MaxCapacity {get; private set; }


        public Location(int id, string locationNumber, int maxCapacity)
        {
            ID = id;
            LocationNumber = locationNumber;
            MaxCapacity = maxCapacity;
        }
    }
    
}
