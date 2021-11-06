using Microsoft.EntityFrameworkCore;
using USSDiscovery.Domain;

namespace USSDiscovery.Infra.Data.Context
{
    public class USSDiscoveryContext : DbContext
    {
        public USSDiscoveryContext(DbContextOptions<USSDiscoveryContext> options) 
            : base(options) 
        {

        }
        public DbSet<Planeta> Planetas { get; set; }
    }
}