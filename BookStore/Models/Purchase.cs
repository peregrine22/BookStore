using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Purchase
    {
        [Key] public int Purchase_Id { get; set; }
        [Required] public DateTime Date { get; set; }
        [Required] public int Books_Id { get; set; }
        [Required] public int Users_Id { get; set; }
    }

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class PurchaseContext : DbContext
    {
        public DbSet<Purchase> Purchases { get; set; }

        public PurchaseContext() : base("connection")
        { }
    }
}