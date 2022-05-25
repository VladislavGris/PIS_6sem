using Data.Models;
using System.Data.Entity;

namespace SQLRepository
{
    internal class PhoneBookContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public PhoneBookContext() : base("DbConnection")
        {

        }
    }
}
