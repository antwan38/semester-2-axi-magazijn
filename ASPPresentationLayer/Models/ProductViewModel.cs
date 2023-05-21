
using System.ComponentModel.DataAnnotations;

namespace ASPPresentationLayer.Models
{
    public class ProductViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Geef een naam aan."), MaxLength(50)] 
        public string Name { get; set; }

        [Required(ErrorMessage = "Geef een barcode aan."), MaxLength(50)]
        public string Barcode { get; set; }

        [Required(ErrorMessage = "Geef een geldige hoeveelheid aan.")]
        public int Amount { get; set; }

        public MeasurementsViewModel Measurements { get; set; }

        public LocationViewModel Location { get; set; }

        public CategoryViewModel Category { get; set; }

    }
}
       