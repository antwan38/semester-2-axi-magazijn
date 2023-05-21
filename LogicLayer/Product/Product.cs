using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace LogicLayer
{
    public class Product
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Barcode { get; private set; }
        public int Amount { get; private set; }

        public Measurements Size { get; private set; }
        public Location Location { get; private set; }
        public Category Category { get; private set; }

        private IProduct _IProduct;

        public Product(int id, string name, string barcode, int amount, Location location, Category category, Measurements size, IProduct iProduct)
        {
            ID = id;
            Name = name;
            Barcode = barcode;
            Amount = amount;
            Location = location;
            Category = category;
            Size = size;
            _IProduct = iProduct;
        }

        public Product(string name, string barcode, int amount, Location location, Category category, Measurements size, IProduct iProduct)
        {  
            Name = name;
            Barcode = barcode;
            Amount = amount;
            Location = location;
            Category = category;
            Size = size;
            _IProduct = iProduct;
        }

        public Product(ProductDTO dto)
        {
            ID = dto.ID;
            Name = dto.Name;
            Barcode = dto.Barcode;
            Amount = dto.Amount;
            Location = new Location(dto.Location);
            Category = new Category(dto.Category);
            Size = new Measurements(dto.Size);
        }

        public void Save()
        {
            ProductDAL dal = new ProductDAL();
            dal.Save(ToDTO());
        }

        public void Update()
        {
            ProductDAL dal = new ProductDAL();
            dal.Edit(ToDTO());
        }

        public void Delete()
        {
            ProductDAL dal = new ProductDAL();
            dal.Delete(ID);
        }

        private ProductDTO ToDTO()
        {
            return new ProductDTO
            {
                ID = this.ID,
                Name = this.Name,
                Barcode = this.Barcode,
                Amount = this.Amount,
                Location = new LocationDTO
                {
                    ID = Location.ID,
                    LocationNumber = Location.LocationNumber,
                    MaxCapacity = Location.MaxCapacity
                },
                Category = new CategoryDTO
                {
                    ID = Category.ID,
                    Name = Category.Name
                },
                Size = new MeasurementsDTO
                {
                    Height = this.Size.Height,
                    Width = this.Size.Width,
                    Length = this.Size.Length

                }
            };
        }
    }
}
