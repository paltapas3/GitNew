using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using WebAPICore.Models;

namespace WebAPICore.Models
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options)
            :base(options) { }

        public UserDBContext() { }

        public DbSet<UserAccount> TodoItems { get; set; }

        public string ConnectionString { get; set; }

        public UserDBContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<UserAccount> GetAllUser()
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from UserAccount", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserList._userList.Add(new UserAccount()
                        {
                            Id = reader["Id"].ToString(),
                            Name = reader["Name"].ToString(),
                            Address = reader["Address"].ToString(),
                            Pan = reader["Pan"].ToString(),
                            Account_Type = reader["Account_Type"].ToString(),
                            Balance = reader["Balance"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Email = reader["Email"].ToString(),
                            DOB = reader["DOB"].ToString()
                        });
                    }
                }
                return UserList._userList;
            }
        }
    }
}