using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cadastro
{
    public class Functions
    {
        public static List<User> userList = new List<User>();
        public static string ConnectionsDB => "server=127.0.0.1;User Id=root;database=register;password=''";

        public static User GetUserByLogin(string login)
        {
            User user = new User();
            MySqlConnection connection = new MySqlConnection(ConnectionsDB);
            string query = $"SELECT top 1 * FROM user WHERE Login = @Login";
            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("Login", login);
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

            return user;
        }
        public static User GetUserByID(Int32 id)
        {
            User user = new User();

            MySqlConnection connection = new MySqlConnection(ConnectionsDB);
            string query = $"SELECT * FROM user WHERE Id = @Id LIMIT 1";
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", id);
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

            return user;
        }
        public static void UserInsert(User user)
        {
            userList.Add(user);
            MySqlConnection connection = new MySqlConnection(ConnectionsDB);
            string query = $"INSERT INTO user (Name, Email, Login, Password) values (@Name," +
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
        public static List<User> GetUsersList()
        {
            List<User> users = new List<User>();
            MySqlConnection connection = new MySqlConnection(ConnectionsDB);
            string query = $"SELECT * FROM user";
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    users.Add(new User(dataReader));
                }
                connection.Dispose();
            }
            catch (MySqlException ex)
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

            return users;
        }
        public static User UserUpdate(Int32 id, string name, string email, string login, string password)
        {
            User user = new User();
            userList.Add(user);
            MySqlConnection connection = new MySqlConnection(ConnectionsDB);
            string query = $"UPDATE user set Name = @Name, Email = @Email, Login = @Login, Password = @Password " +
                $"WHERE Id = @Id";
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                command.Parameters.AddWithValue("Name", name);
                command.Parameters.AddWithValue("Email", email);
                command.Parameters.AddWithValue("Login", login);
                command.Parameters.AddWithValue("Password", password);
                command.Parameters.AddWithValue("Id", id);

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
            return user;
        }
        public static User UserDelete(Int32 id)
        {
            User user = new User();
            MySqlConnection connection = new MySqlConnection(ConnectionsDB);
            string query = $"DELETE from user where Id = @Id";
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                command.Parameters.AddWithValue("Id", id);

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

            return user;
        }
        public static List<User> UserSearch(string id, string name, string email)
        {
            List<User> users = new List<User>();
            MySqlConnection connection = new MySqlConnection(ConnectionsDB);
            string query = $"SELECT id, Nome, Email, Login, Senha  FROM usuario ";
            string queryWhere = string.Empty; //--Criado para armazenar apenas as condições sem o WHERE

            if (id != string.Empty)
            {
                //--If para verificar se existe condição adicionada a var queryWhere, se já existir condição deverá ser adicionado o operador and
                if(queryWhere != string.Empty){
                    queryWhere += " AND ";
                }
                queryWhere += " id = @id ";
            }
            if (name != string.Empty)
            {
                //--If para verificar se existe condição adicionada a var queryWhere, se já existir condição deverá ser adicionado o operador and
                if(queryWhere != string.Empty){
                    queryWhere += " AND ";
                }
                queryWhere += " upper(nome) like '%" + @name + "%'";
            }
            if (email != string.Empty)
            {
                //--If para verificar se existe condição adicionada a var queryWhere, se já existir condição deverá ser adicionado o operador and
                if(queryWhere != string.Empty){
                    queryWhere += " AND ";
                }
                queryWhere += " upper(email) like '%" + @email + "%'";
            }

            //--Se no fim houver condição no var queryWhere então adicionar a var query e adicionando o operador WHERE na sentença
            if(queryWhere != string.Empty){
                query = " WHERE " + queryWhere;
            }

            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@nome", name.Trim().ToUpper());
                command.Parameters.AddWithValue("@email", email.Trim().ToUpper());
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    users.Add(new User(dataReader));
                }
            }
            catch (MySqlException ex)
            {
                string message = ex.ToString();
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
            }
            finally
            {
                connection.Close();
            }
            return users;
        }

    }
}