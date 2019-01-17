using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class User
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Last_Name { get; set; }
        [Required] public int Age { get; set; }
    }

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext() : base("connection")
        { }
    }
}