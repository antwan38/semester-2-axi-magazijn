using System;
namespace DataAccessLayer
{
	public struct BranchDTO
	{
		public int ID { get; set; }
		public string PlaceName { get; set; }
		public string StreetName { get; set; }
		public string HouseNumber { get; set; }
		public string PostalCode { get; set; }
	}
}

