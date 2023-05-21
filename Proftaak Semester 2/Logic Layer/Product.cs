using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_Semester_2
{
    public class Product
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Barcode { get; private set; }
        public int Amount { get; private set; }
        public Location Location { get; private set; }

        public Product(int id, string name, string barcode, int amount, Location location)
        {
            ID = id;
            Name = name;
            Barcode = barcode;
            Amount = amount;
            Location = location;
        }
    }
}
