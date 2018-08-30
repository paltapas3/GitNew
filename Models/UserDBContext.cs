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
    }
}