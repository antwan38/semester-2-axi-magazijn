using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public struct ProductDTO
    {
        public int ID;
        public MeasurementsDTO Size;
        public string Name;
        public string Barcode;
        public int Amount;
        public LocationDTO Location;
        public CategoryDTO Category;
    }
}
