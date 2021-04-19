using Microsoft.EntityFrameworkCore;
using DIS_Assignment4.Models;

namespace DIS_Assignment4.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Key> Keys { get; set; }
        public DbSet<Datum> Datums { get; set; }


    }
}