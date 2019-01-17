using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Book
    {
        [Key] public int Books_Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Author { get; set; }
        [Required] public int Pages { get; set; }
        [Required] public int Price { get; set; }
    }
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookContext() : base("connection")
        { }
    }
}