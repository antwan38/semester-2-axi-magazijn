using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Proftaak_Semester_2
{
    class DatabaseClass : ConnectionManager
    {
        private string Query {get;}

        public DatabaseClass(string query)
        {
            this.Query = query;
        }
        
        public void Add(Product product)
        {
            OpenConn();
            SqlCommand cmd = new SqlCommand(Query, Conn);
            SqlDataReader reader = cmd.ExecuteReader();
            CloseConn();
        }

        public void Edit(Product product)
        {
            OpenConn();
            string query = $"UPDATE Product SET Barcode = '{product.Barcode}', Naam = '{product.Name}', " +
                $"Aantal = {product.Amount}" + /*, LocatieID = {product.Location.ID}, CategorieID = {product.Category.ID} */
                $" WHERE ID = {product.ID}";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.ExecuteNonQuery();
            CloseConn();
        }

        public List<Product> GetAllProducts()
        {
            var result = new List<Product>();
            OpenConn();
            SqlCommand cmd = new SqlCommand(Query, Conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Product((int)reader["ID"], (string)reader["Naam"], (string)reader["Barcode"],
                        (int)reader["Aantal"], new Location((int)reader["LocatieID"], "null", 99999)));
                }
            }

            CloseConn();
            return result;
        }

        public void Delete(string ID)
        {
            
            string query = $"delete from Product where ID = {ID}";
            OpenConn();
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.ExecuteNonQuery();
            CloseConn();
            
        }
    }
}

    