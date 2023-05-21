using System;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public abstract class ConnectionManager
    {
        protected SqlConnection Conn;
        private const string ConnectionString =
            "Server = mssqlstud.fhict.local; Database=dbi476472;User Id = dbi476472; Password=Welkom2022";

        protected ConnectionManager()
        {
            Conn = new SqlConnection(ConnectionString);
        }

       
        protected void OpenConn()
        {
            try
            {
                Conn.Open();
            }
            catch (Exception e)
            {
                //Conn.Close();
            }
        }

        protected void CloseConn()
        {
            try
            {
                Conn.Close();
            }
            catch (Exception e)
            {

            }   
        }
    }   
}
