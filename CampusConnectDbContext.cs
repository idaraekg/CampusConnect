using Microsoft.EntityFrameworkCore;
using CampusConnect.Models;

namespace CampusConnect.Data
{
    public class CampusConnectDbContext : DbContext
    {
        public CampusConnectDbContext(DbContextOptions<CampusConnectDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}