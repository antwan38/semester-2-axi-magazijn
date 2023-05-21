using System;
using DataAccessLayer;
using InterfaceLayer;

namespace LogicLayer
{
	public class Branch
	{
		public int ID { get; private set; }
		public string PlaceName { get; private set; }
		public string StreetName { get; private set; }
		public string HouseNumber { get; private set; }
		public string PostalCode { get; private set; }

		private IBranch _IBranch;

		public Branch(int id, string placeName, string streetName, string houseNumber, string postalCode, IBranch iBranch)
		{
			ID = id;
			PlaceName = placeName;
			StreetName = streetName;
			HouseNumber = houseNumber;
			PostalCode = postalCode;
			_IBranch = iBranch;
		}
		public Branch(int id, string placeName, string streetName, string houseNumber, string postalCode)
		{
			ID = id;
			PlaceName = placeName;
			StreetName = streetName;
			HouseNumber = houseNumber;
			PostalCode = postalCode;
		}

		public Branch(string placeName, string streetName, string houseNumber, string postalCode, IBranch iBranch)
		{
			PlaceName = placeName;
			StreetName = streetName;
			HouseNumber = houseNumber;
			PostalCode = postalCode;
			_IBranch = iBranch;
		}

		public Branch(BranchDTO dto)
        {
			ID = dto.ID;
			PlaceName = dto.PlaceName;
			StreetName = dto.StreetName;
			HouseNumber = dto.HouseNumber;
			PostalCode = dto.PostalCode;
        }

        public void Save()
        {
	        _IBranch.Save(ToDTO());
        }

        public BranchDTO ToDTO()
        {
			return new BranchDTO
			{
				ID = ID,
				PlaceName = PlaceName,
				StreetName = StreetName,
				HouseNumber = HouseNumber,
				PostalCode = PostalCode
			};
        }
	}
}

