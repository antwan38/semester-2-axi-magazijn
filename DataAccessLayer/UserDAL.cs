using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using InterfaceLayer;

namespace DataAccessLayer
{
    public class UserDAL : ConnectionManager, IUser, IUserContainer
    {
        /// <summary>
        /// Takes values from the UserDTO and Inserts them into
        /// the Database
        /// </summary>
        /// <param name="data"></param>
        /// <returns>
        /// Return True when a row was created in the database
        /// Return false when no row was created
        /// </returns>
        public bool Save(UserDTO data)
        {
            try
            {
                OpenConn();
                string query =
                    "INSERT INTO [User] (Username,Email,Password, Role) VALUES (@Username, @Email, @Password, @Role)";

                SqlCommand command = new SqlCommand(query, Conn);
                command.Parameters.AddWithValue("@Username", data.UserName);
                command.Parameters.AddWithValue("@Email", data.Mail);
                command.Parameters.AddWithValue("@Password", data.PasswordHash);
                command.Parameters.AddWithValue("@Role", data.Role);
                command.ExecuteNonQuery();
                CloseConn();
                return true;
            }
            catch (Exception)
            {
                CloseConn();
                throw;

            }
        }

        /// <summary>
    /// Takes a email to use and find the corresponding PasswordHash,
    /// UserName and ID
    /// </summary>
    /// <param name="email"></param>
    /// <returns>
    /// Return UserDTO with the value's ID, PasswordHash and Username
    /// </returns>
    public UserDTO GetUserByMail(string email)
    {
        UserDTO dto = new UserDTO();
        string query = $"SELECT * FROM [User] where Email = @email";
        using (SqlCommand command = new SqlCommand(query, Conn))
        {
            command.Parameters.AddWithValue("@email", email);
            OpenConn();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    dto.UserID = Convert.ToInt32(reader["ID"]);
                    dto.UserName = Convert.ToString(reader["Username"]);
                    dto.Mail = Convert.ToString(reader["Email"]);
                    dto.PasswordHash = Convert.ToString(reader["Password"]);
                    dto.Role = Convert.ToInt32(reader["Role"]);


                    CloseConn();
                    return dto;
                }
            }
        }

        return dto;
    }
}

}