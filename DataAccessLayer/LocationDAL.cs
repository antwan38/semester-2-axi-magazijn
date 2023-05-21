
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class LocationDAL : ConnectionManager, ILocation, ILocationContainer
    {
        public void Save(LocationDTO location)
        {
            OpenConn();
            //change
            string query = $"INSERT into Locatie (Capaciteit, LocatieNr, VestigingID) values ( @MaxCapacity, @LocationNumber, @VestigingID);";
            //change
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@MaxCapacity", (int)location.MaxCapacity));
            cmd.Parameters.Add(new SqlParameter("@LocationNumber", location.LocationNumber));
            cmd.Parameters.Add(new SqlParameter("@VestigingID", location.Branch.ID));
          
            cmd.ExecuteNonQuery();
            CloseConn();
        }

        public void Edit(ProductDTO product)
        {
            OpenConn();
            string query = $"UPDATE Product SET Barcode = @Barcode, Naam = @Name, " +
                $"Aantal = @Amount" + /*, LocatieID = {product.Location.ID}, CategorieID = {product.Category.ID} */
                $" WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@Barcode", product.Barcode));
            cmd.Parameters.Add(new SqlParameter("@Name", product.Name));
            cmd.Parameters.Add(new SqlParameter("@Amount", product.Amount));
            cmd.Parameters.Add(new SqlParameter("@ID", product.ID));
            CloseConn();
        }

        public void Delete(int id)
        {
            string query = $"DELETE FROM Product WHERE ID = @id";
            OpenConn();
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.ExecuteNonQuery();
            CloseConn();
        }

        public List<LocationDTO> GetAll()
        {
            var result = new List<LocationDTO>();
            string query = "SELECT * FROM Locatie l INNER JOIN Vestiging v on l.VestigingID = v.ID";
            OpenConn();
            SqlCommand cmd = new SqlCommand(query, Conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    BranchDTO branch = new BranchDTO
                    {
                        ID = (int)reader["VestigingID"],
                        PlaceName = (string)reader["Plaats"],
                        StreetName = (string)reader["Straatnaam"],
                        HouseNumber = (string)reader["Huisnummer"],
                        PostalCode = (string)reader["Postcode"]
                    };

                    result.Add(
                        new LocationDTO
                        {
                            ID = (int)reader["ID"],
                            LocationNumber = (string)reader["LocatieNr"],
                            MaxCapacity = (int)reader["Capaciteit"],
                            Branch = branch
                        });
                }
            }

            CloseConn();
            return result;
        }

        public LocationDTO GetById(int id)
        {
            string query = "SELECT * FROM Locatie l INNER JOIN Vestiging v on l.VestigingID = v.ID WHERE l.ID = @ID";
            OpenConn();

            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            LocationDTO result = new LocationDTO();

            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                BranchDTO branch = new BranchDTO
                {
                    ID = (int)reader["VestigingID"],
                    PlaceName = (string)reader["Plaats"],
                    StreetName = (string)reader["Straatnaam"],
                    HouseNumber = (string)reader["Huisnummer"],
                    PostalCode = (string)reader["Postcode"]
                };
                
                result = new LocationDTO()
                {
                    ID = (int)reader["ID"],
                    LocationNumber = (string)reader["LocatieNr"],
                    MaxCapacity = (int)reader["Capaciteit"],
                    Branch = branch
                };
            }

            CloseConn();
            return result;
        }
    }
}

