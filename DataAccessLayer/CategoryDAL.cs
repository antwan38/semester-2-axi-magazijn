using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class CategoryDAL : ConnectionManager, ICategory, ICategoryContainer
    {
        public List<CategoryDTO> GetAll()
        {
            var result = new List<CategoryDTO>();
            string query = "select* from Categorie";
            OpenConn();
            SqlCommand cmd = new SqlCommand(query, Conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(
                        new CategoryDTO
                        {

                            ID = (int)reader["ID"],
                            Name = (string)reader["Naam"],
                            
                        });
                }
            }

            CloseConn();
            return result;
        }

        public CategoryDTO GetbyId(int id)
        {
            CategoryDTO result = new CategoryDTO();
            string query = "select* from Categorie WHERE ID = @ID";
            OpenConn();
            
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@ID", id));

            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result = new CategoryDTO()
                {
                    ID = (int)reader["ID"],
                    Name = (string)reader["Naam"],
                };
            }

            CloseConn();
            return result;
        }

        public void Save(CategoryDTO category)
        {
            OpenConn();
            string query = $"insert into Categorie (Naam) values (@Name);";
            SqlCommand cmd = new SqlCommand(query, Conn);
            
            cmd.Parameters.Add(new SqlParameter("@Name", category.Name));
            cmd.ExecuteNonQuery();
            CloseConn();
        }
    }
}
