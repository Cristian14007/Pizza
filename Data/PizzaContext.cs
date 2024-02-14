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

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 1, Name = "Jamon y queso", IsGlutenFree = true},
                new Pizza { Id = 2, Name = "Carbonara", IsGlutenFree = false}
            );
            modelBuilder.Entity<Ingrediente>().HasData(
                new Ingrediente { Id = 1, Name = "Jamon", Origen = "Animal", Calorias = 15 },
                new Ingrediente { Id = 2, Name = "Champiñones", Origen = "Vegetal", Calorias = 48 }
                
            );
        }


        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }

    }

}