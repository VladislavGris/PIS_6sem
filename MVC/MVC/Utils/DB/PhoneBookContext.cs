using MVC.Models;
using System.Data.Entity;

namespace MVC.Utils.DB
{
    public class PhoneBookContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public PhoneBookContext() : base("DbConnection")
        {

        }
    }
}