using ASPPresentationLayer.Models;
using LogicLayer;

namespace ASPPresentationLayer.Controllers
{
    public static class ViewModelConverter
    {
        public static ProductViewModel ToViewModel(Product product)
        {
            return new ProductViewModel
            {
                ID = product.ID,
                Name = product.Name,
                Amount = product.Amount,
                Category = ToViewModel(product.Category),
                Barcode = product.Barcode,
                Location = ToViewModel(product.Location)
            };
        }

        public static CategoryViewModel ToViewModel(Category category)
        {
            return new CategoryViewModel
            {
                ID = category.ID,
                Name = category.Name,
            };
        }

        public static LocationViewModel ToViewModel(Location location)
        {
            return new LocationViewModel
            {
                ID = location.ID,
                LocationNumber = location.LocationNumber,
                MaxCapacity = location.MaxCapacity,
                Branch = ToViewModel(location.Branch)
            };
        }

        public static BranchViewModel ToViewModel(Branch branch)
        {
            return new BranchViewModel
            {
                ID = branch.ID,
                PlaceName = branch.PlaceName,
                StreetName = branch.StreetName,
                PostalCode = branch.PostalCode,
                HouseNumber = branch.HouseNumber
            };
        }
    }
}
