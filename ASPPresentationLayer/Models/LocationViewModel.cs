using System.ComponentModel.DataAnnotations;

namespace ASPPresentationLayer.Models
{
    public class LocationViewModel
    {
        public int ID { get; set; }
        [MaxLength(10)]
        public string? LocationNumber { get; set; }
        public int MaxCapacity { get; set; }
        public BranchViewModel? Branch { get; set; }

    }
    
}
