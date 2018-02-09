using ArchitectureNetCore.Data.EF.Context;
using ArchitectureNetCore.Domain.Entities;
using System.Linq;

namespace ArchitectureNetCore.Data.EF
{
    public class DbInitializer
    {
        public static void Initialize()
        {
            var context = new AppDbContext();
            context.Database.EnsureCreated();

            if (context.Trucks.Any())
            {
                return;   // Já contém dados
            }

            var trucks = new Truck[]
            {
                new Truck { ID = 1, Name = "R 400", WheelConfiguration = "4x2 c/3º eixo R885", Power = "Motor 13 litros – Proconve Fase 7 DC13 113 400 cv", Weight = 5157 , Observation = "GRS905 - Caixa de câmbio de 3 posições com range e split acionado por interruptor e embreagem, com marcha superlenta (crawler). 14 velocidades (2 superlenta)" },
                new Truck { ID = 2, Name = "R 620", WheelConfiguration = "6x4 RBP835 RP835", Power = "Motor 20 litros – Proconve Fase 7 DC13 113 400 cv", Weight = 9000 , Observation = "Freios totalmente pneumáticos de duplo circuito e ação direta, com circuitos independentes para freios dianteiros e traseiros, de estacionamento e de emergência." },                
            };
            context.Trucks.AddRange(trucks);
            context.SaveChanges();
        }
    }
}
