using System.Collections.Generic;

namespace ArchitectureNetCore.Domain.Entities
{
    public class Truck
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string WheelConfiguration { get; set; }
        public string Power { get; set; }
        public int Weight { get; set; }
        public string Observation { get; set; }
    }
}
