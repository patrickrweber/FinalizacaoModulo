using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Register
{
    public class Functions
    {

        public static string GetConnectionsDB()
        {
            return "server=127.0.0.1;User Id=root;database=register_db;password=''";
        }
        private static void UserInsert(User user)
        {
            
            MySqlConnection connection = new MySqlConnection(GetConnectionsDB());
            string query = "INSERT INTO user (Name, Email, Login, Password) values (@Name," +
                "@Email, @Login, @Password)";

            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Login", user.Login);
                command.Parameters.AddWithValue("@Password", user.Password);

                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    user = new User(dataReader);
                }
                connection.Dispose();
            }
            catch(MySqlException ex)
            {
                string message = ex.ToString();

            }
            catch(Exception ex)
            {
                string message = ex.ToString();
            }
            finally
            {
                connection.Close();
            }

           

        }



    }
}