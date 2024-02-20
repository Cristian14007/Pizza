using Microsoft.EntityFrameworkCore;
using PizzaExample.Models;
using Microsoft.Extensions.Configuration;

namespace PizzaExample.Data{

    public class PizzaContext : DbContext
    {

        public PizzaContext(DbContextOptions<PizzaContext> options)
            : base(options)
        {

        }

        /* protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 1, Name = "Jamon y queso", IsGlutenFree = true},
                new Pizza { Id = 2, Name = "Carbonara", IsGlutenFree = false}
            );
            modelBuilder.Entity<Ingrediente>().HasData(
                new Ingrediente { Id = 1, Name = "Jamon", Origen = "Animal", Calorias = 15 },
                new Ingrediente { Id = 2, Name = "Champiñones", Origen = "Vegetal", Calorias = 48 }
                
            );
        } */

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<PizzaIngrediente>()
        .HasKey(pi => new { pi.PizzaId, pi.IngredienteId });

    modelBuilder.Entity<PizzaIngrediente>()
        .HasOne(pi => pi.Pizza)
        .WithMany(p => p.PizzaIngredientes)
        .HasForeignKey(pi => pi.PizzaId);

    modelBuilder.Entity<PizzaIngrediente>()
        .HasOne(pi => pi.Ingrediente)
        .WithMany(i => i.PizzaIngredientes)
        .HasForeignKey(pi => pi.IngredienteId);

        modelBuilder.Entity<PizzaDTO>().HasData(
    new Pizza { PizzaId = 1, Nombre = "Hawaiana" },
    new Pizza { PizzaId = 2, Nombre = "Barbacoa" }
);

modelBuilder.Entity<IngredienteDTO>().HasData(
    new Ingrediente { IngredienteId = 1, Nombre = "Piña" },
    new Ingrediente { IngredienteId = 2, Nombre = "Jamón york" },
    new Ingrediente { IngredienteId = 3, Nombre = "Carne picada" }
);

modelBuilder.Entity<PizzaIngrediente>().HasData(
    new PizzaIngrediente { PizzaId = 1, IngredienteId = 1 },
    new PizzaIngrediente { PizzaId = 1, IngredienteId = 2 },
    new PizzaIngrediente { PizzaId = 2, IngredienteId = 3 }
);
        }


        

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }

    }

}