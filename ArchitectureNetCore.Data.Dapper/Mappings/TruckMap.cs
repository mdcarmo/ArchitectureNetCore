using ArchitectureNetCore.Domain.Entities;
using Dapper.FluentMap.Dommel.Mapping;

namespace ArchitectureNetCore.Data.Dapper.Mappings
{
    public class TruckMap: DommelEntityMap<Truck>
    {
        public TruckMap()
        {
            ToTable("Truck");
            Map(p => p.ID).IsKey();
        }
    }
}
