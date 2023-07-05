using DatingAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Appuser> Users { get; set; }
    }
}
