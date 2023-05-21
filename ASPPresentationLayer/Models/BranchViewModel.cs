using System;
using System.ComponentModel.DataAnnotations;

namespace ASPPresentationLayer.Models
{
	public class BranchViewModel
	{
		public int ID { get; set; }

		[Required(ErrorMessage = "Geef een plaatsnaam aan."), MaxLength(100)]
		public string PlaceName { get; set; }
		[Required(ErrorMessage = "Geef een straatnaam aan."), MaxLength(50)]
		public string StreetName { get; set; }
		[Required(ErrorMessage = "Geef een huisnummer aan."), MaxLength(10)]
		public string HouseNumber { get; set; }
		[Required(ErrorMessage = "Geef een postcode aan."), MaxLength(6)]
		public string PostalCode { get; set; }
	}
}

