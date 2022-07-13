using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Register
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email {get; set;}
        public string Login {get; set;}
        public string Password {get; set;}

        public User() { }

        public User(string name, string email, string login, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Login = login;
            this.Password = password;
        }

        public User(MySqlDataReader dataReader)
        {
            this.Id = !dataReader.IsDBNull(0) ? dataReader.GetInt32(0) : 0;
            this.Name = !dataReader.IsDBNull(1) ? dataReader.GetString(1) : "";
            this.Email = !dataReader.IsDBNull(2) ? dataReader.GetString(2) : "";
            this.Login = !dataReader.IsDBNull(3) ? dataReader.GetString(3) : "";
            this.Password = !dataReader.IsDBNull(4) ? dataReader.GetString(4) : "";
        }
    }
}