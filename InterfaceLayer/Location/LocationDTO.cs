using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public struct LocationDTO
    {
        public int ID;
        public string LocationNumber;
        public int MaxCapacity;
        public BranchDTO Branch;
    }
}
