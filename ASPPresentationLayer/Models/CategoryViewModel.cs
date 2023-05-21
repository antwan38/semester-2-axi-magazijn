

using System.ComponentModel.DataAnnotations;

namespace ASPPresentationLayer.Models
{
    public class CategoryViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Geef een naam aan."), MaxLength(50)]
        public string Name { get; set; }

    }
}
