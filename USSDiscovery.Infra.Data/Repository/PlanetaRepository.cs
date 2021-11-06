using USSDiscovery.Domain;
using USSDiscovery.Domain.Interfaces;
using USSDiscovery.Infra.Data.Context;

namespace USSDiscovery.Infra.Data.Repository
{
    public class PlanetaRepository : Repository<Planeta>, IPlanetaRepository
    {
        public PlanetaRepository(USSDiscoveryContext context)
                : base(context)
        {
        }
    }
}