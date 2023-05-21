using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class BranchDAL : ConnectionManager, IBranch, IBranchContainer

    {
    public int Save(BranchDTO branch)
    {
        OpenConn();
        string query =
            $"INSERT into Vestiging (Plaats, Straatnaam, Huisnummer, Postcode) values (@Plaatsnaam, @Straat, @Huisnummer, @Postcode);";
        SqlCommand cmd = new SqlCommand(query, Conn);
        cmd.Parameters.Add(new SqlParameter("@Plaatsnaam", branch.PlaceName));
        cmd.Parameters.Add(new SqlParameter("@Straat", branch.StreetName));
        cmd.Parameters.Add(new SqlParameter("@Huisnummer", branch.HouseNumber));
        cmd.Parameters.Add(new SqlParameter("@PostCode", branch.PostalCode));
        int savedRows = cmd.ExecuteNonQuery();
        CloseConn();
        return savedRows;
    }

    public List<BranchDTO> GetAll()
    {
        List<BranchDTO> result = new List<BranchDTO>();
        string query = "SELECT * FROM Vestiging";
        OpenConn();
        SqlCommand cmd = new SqlCommand(query, Conn);

        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                result.Add(
                    new BranchDTO
                    {
                        ID = (int) reader["ID"],
                        PlaceName = (string) reader["Plaats"],
                        StreetName = (string) reader["Straatnaam"],
                        HouseNumber = (string) reader["Huisnummer"],
                        PostalCode = (string) reader["Postcode"],
                    });
            }
        }

        CloseConn();
        return result;
    }

    public BranchDTO Get(int id)
    {
        string query = "SELECT * FROM Vestiging WHERE ID = @ID";
        OpenConn();

        SqlCommand cmd = new SqlCommand(query, Conn);
        cmd.Parameters.Add(new SqlParameter("@ID", id));
        BranchDTO result = new BranchDTO();

        SqlDataReader reader;
        reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            result = new BranchDTO
            {
                ID = id,
                PlaceName = (string) reader["Plaats"],
                StreetName = (string) reader["Straatnaam"],
                HouseNumber = (string) reader["Huisnummer"],
                PostalCode = (string) reader["Postcode"],
            };
        }

        CloseConn();
        return result;
    }
    }
}

