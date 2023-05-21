
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDAL : ConnectionManager, IProduct, IProductContainer
    {

        public void Save(ProductDTO product)
        {
            OpenConn();
            string query = $"INSERT into Product (Barcode, Naam, Aantal, LocatieID, CategorieID, Lengte, Breedte, Hoogte) values (@Barcode, @Name, @Amount, @LocationID , @CategoryID, @Lengte, @Breedte, @Hoogte);";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@Barcode", product.Barcode));
            cmd.Parameters.Add(new SqlParameter("@Name", product.Name));
            cmd.Parameters.Add(new SqlParameter("@Amount", product.Amount));
            cmd.Parameters.Add(new SqlParameter("@LocationID", product.Location.ID));
            cmd.Parameters.Add(new SqlParameter("@CategoryID", product.Category.ID));
            cmd.Parameters.Add(new SqlParameter("@Lengte", product.Size.Length));
            cmd.Parameters.Add(new SqlParameter("@Breedte", product.Size.Width));
            cmd.Parameters.Add(new SqlParameter("@Hoogte", product.Size.Height));
            cmd.ExecuteNonQuery();
            CloseConn();
        }

        public void Edit(ProductDTO product)
        {
            OpenConn();
            string query = $"UPDATE Product SET Barcode = @Barcode, Naam = @Name, " +
                $"Aantal = @Amount, LocatieID = @LocationID, CategorieID = @CategoryID" +
                $" WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@Barcode", product.Barcode));
            cmd.Parameters.Add(new SqlParameter("@Name", product.Name));
            cmd.Parameters.Add(new SqlParameter("@Amount", product.Amount));
            cmd.Parameters.Add(new SqlParameter("@LocationID", product.Location.ID));
            cmd.Parameters.Add(new SqlParameter("@CategoryID", product.Category.ID));
            cmd.Parameters.Add(new SqlParameter("@ID", product.ID));
            cmd.ExecuteNonQuery();
            CloseConn();
        }

        public void Delete(int id)
        {
            string query = $"DELETE FROM Product WHERE ID = @ID";
            OpenConn();
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            cmd.ExecuteNonQuery();
            CloseConn();
        }

        private LocationDTO GetLocation(int locationID)
        {
            
            string query = $"SELECT * FROM Locatie WHERE id = @ID";
            OpenConn();

            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@ID", locationID));
            LocationDTO result = new LocationDTO();

            SqlDataReader reader;
               reader = cmd.ExecuteReader();
            
                while (reader.Read())
                {
                    result = new LocationDTO
                    {
                        ID = locationID,
                        LocationNumber = (string)reader["LocatieNr"],
                        MaxCapacity = (int)reader["Capaciteit"],
                        Branch = new BranchDAL().Get((int)reader["VestigingID"])
                    };
                }
            CloseConn();
            return result;
        }

        private CategoryDTO GetCategory(int categoryID)
        {

            string query = $"SELECT * FROM Categorie WHERE id = @ID";
            OpenConn();

            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@ID", categoryID));
            CategoryDTO result = new CategoryDTO();

            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result = new CategoryDTO
                {
                    ID = categoryID,
                    Name = (string)reader["Naam"]
                };
            }
            CloseConn();
            return result;
        }

        public List<ProductDTO> GetAll()
        {
            List<ProductDTO> result = new List<ProductDTO>();
            List<ProductDTO> realresult = new List<ProductDTO>();
            string query = "SELECT * FROM Product";
            OpenConn();
            SqlCommand cmd = new SqlCommand(query, Conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {   
                    // list met id locatie
                    result.Add(
                        new ProductDTO
                    {
                        ID = (int)reader["ID"],
                        Name = (string)reader["Naam"],
                        Barcode = (string)reader["Barcode"],
                        Amount = (int)reader["Aantal"],
                        Location = new LocationDTO
                        {
                            ID = (int)reader["LocatieID"]
                        },
                        Category = new CategoryDTO
                        {
                            ID = (int)reader["CategorieID"]
                        },
                        Size = new MeasurementsDTO
                        {
                            Width = (decimal)reader["Breedte"],
                            Height = (decimal)reader["Hoogte"],
                            Length = (decimal)reader["Lengte"]
                        }
                        
                    });
                }
            }

            CloseConn();

            for (int i = 0; i < result.Count; i++)
            {
                realresult.Add( new ProductDTO 
                { 
                    
                    
                        ID = result[i].ID,
                        Name = result[i].Name,
                        Barcode = result[i].Barcode,
                        Amount = result[i].Amount,
                        Location = GetLocation(result[i].Location.ID),
                        Category = GetCategory(result[i].Category.ID)
                });
                
            }

            return realresult;
        }

        // outsourced:
        public List<ProductDTO> GetListOfProductsOnFilter(string naam, string filterCategorie, string filterBranch )
        {
            if ((filterBranch == null || filterBranch == "Geen") && (filterCategorie != null || filterCategorie != "Geen"))
            {
                var result = new List<ProductDTO>();
                string query = @"select * from Product
                inner join Categorie on Product.CategorieID = Categorie.ID
                where Product.Naam like '%'+@naam+'%' AND Categorie.Naam = @filter OR Product.Barcode like '%'+@naam+'%' AND Categorie.Naam = @filter";
                OpenConn();
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@naam", naam);
                cmd.Parameters.AddWithValue("@filter", filterCategorie);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(
                            new ProductDTO
                            {
                                ID = (int)reader["ID"],
                                Name = (string)reader["Naam"],
                                Barcode = (string)reader["Barcode"],
                                Amount = (int)reader["Aantal"],
                                Location = new LocationDTO { ID = (int)reader["LocatieID"] },
                                Category = new CategoryDTO { ID = (int)reader["CategorieID"] }
                            });
                    }
                }
                var realResult = new List<ProductDTO>();
                for (int i = 0; i < result.Count; i++)
                {
                    realResult.Add(new ProductDTO
                    {
                        ID = result[i].ID,
                        Name = result[i].Name,
                        Barcode = result[i].Barcode,
                        Amount = result[i].Amount,
                        Location = GetLocation(result[i].Location.ID),
                        Category = GetCategory(result[i].Category.ID)
                    });

                }

                CloseConn();
                return realResult;
            }
            else
            if ((filterBranch != null || filterBranch != "Geen") && (filterCategorie == null || filterCategorie == "Geen"))
            {
                var result = new List<ProductDTO>();
                string query = @"Select * from Product  inner join Locatie on Product.LocatieID = Locatie.ID inner join Vestiging on Locatie.VestigingID = Vestiging.ID where Product.Naam like '%'+@naam+'%' AND Vestiging.Plaats = @filter OR Product.Barcode like '%'+@naam+'%' AND Vestiging.Plaats = @filter";
                OpenConn();
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@naam", naam);
                cmd.Parameters.AddWithValue("@filter", filterBranch);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(
                            new ProductDTO
                            {
                                ID = (int)reader["ID"],
                                Name = (string)reader["Naam"],
                                Barcode = (string)reader["Barcode"],
                                Amount = (int)reader["Aantal"],
                                Location = new LocationDTO { ID = (int)reader["LocatieID"] },
                                Category = new CategoryDTO { ID = (int)reader["CategorieID"] }
                            });
                    }
                }
                var realResult = new List<ProductDTO>();
                for (int i = 0; i < result.Count; i++)
                {
                    realResult.Add(new ProductDTO
                    {
                        ID = result[i].ID,
                        Name = result[i].Name,
                        Barcode = result[i].Barcode,
                        Amount = result[i].Amount,
                        Location = GetLocation(result[i].Location.ID),
                        Category = GetCategory(result[i].Category.ID)
                    });

                }

                CloseConn();
                return realResult;

            }
            else
            if ((filterBranch != null || filterBranch != "Geen") && (filterCategorie != null || filterCategorie != "Geen"))
            {
                var result = new List<ProductDTO>();
                string query = @"select * from Product
                inner join Locatie on Product.LocatieID = Locatie.ID
                inner join Vestiging on Locatie.VestigingID = Vestiging.ID
				inner join Categorie on Product.CategorieID = Categorie.ID
                where Product.Naam like '%'+@naam+'%' AND Vestiging.Plaats = @filterL And Categorie.Naam = @filterC OR Product.Barcode like '%'+@naam+'%' AND Vestiging.Plaats = @filterL And Categorie.Naam = @filterC";
                OpenConn();
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@naam", naam);
                cmd.Parameters.AddWithValue("@filterC", filterCategorie);
                cmd.Parameters.AddWithValue("@filterL", filterBranch);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(
                            new ProductDTO
                            {
                                ID = (int)reader["ID"],
                                Name = (string)reader["Naam"],
                                Barcode = (string)reader["Barcode"],
                                Amount = (int)reader["Aantal"],
                                Location = new LocationDTO { ID = (int)reader["LocatieID"] },
                                Category = new CategoryDTO { ID = (int)reader["CategorieID"] }
                            });
                    }
                }
                var realResult = new List<ProductDTO>();
                for (int i = 0; i < result.Count; i++)
                {
                    realResult.Add(new ProductDTO
                    {
                        ID = result[i].ID,
                        Name = result[i].Name,
                        Barcode = result[i].Barcode,
                        Amount = result[i].Amount,
                        Location = GetLocation(result[i].Location.ID),
                        Category = GetCategory(result[i].Category.ID)
                    });

                }

                CloseConn();
                return realResult;
                

            
            
                
                


            }
            else
            {
                return new List<ProductDTO>();
            }
    

    
        }
    }
}
