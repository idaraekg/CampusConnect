using Microsoft.EntityFrameworkCore;

namespace CampusConnect.Data
{
    public class CampusConnectDbContext : DbContext
    {
        public CampusConnectDbContext(DbContextOptions<CampusConnectDbContext> options)
            : base(options)
        {
        }
    }
}
