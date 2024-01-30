
using PizzaExample.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzaExample.Data
{
    public class IngredientesRepository : IIngredientesRepository
    {
        private  List<Ingrediente> Ingredientes { get; set; }
        private  int nextId = 1;

        public IngredientesRepository()
        {
            Ingredientes = new List<Ingrediente>
            {
                new Ingrediente { Id = 1, Name = "Pepperoni", Origen = "Animal", Calorias=20},
                new Ingrediente { Id = 2, Name = "Olivas", Origen = "Vegetal", Calorias=13 }
            };
        }

        public  List<Ingrediente> GetAll()
        {
            return Ingredientes;
        }

        public  Ingrediente Get(int id)
        {
            return Ingredientes.FirstOrDefault(p => p.Id == id);
        }

        public  void Add(Ingrediente ingrediente)
        {
            ingrediente.Id = nextId++;
            Ingredientes.Add(ingrediente);
        }

        public  void Update(Ingrediente ingrediente)
        {
            var index = Ingredientes.FindIndex(p => p.Id == ingrediente.Id);
            if (index != -1)
            {
                Ingredientes[index] = ingrediente;
            }
        }

        public  void Delete(int id)
        {
            var ingrediente = Get(id);
            if (ingrediente != null)
            {
                Ingredientes.Remove(ingrediente);
            }
        }

        public List<Ingrediente> GetIngredientesByPizzaId(int pizzaId)
        {
            // Puedes agregar lógica aquí para obtener los ingredientes asociados a una pizza específica
            // Devuelve una lista de ingredientes relacionados con la pizzaId
            return Ingredientes.Where(i => i.PizzaId == pizzaId).ToList();
        }

        public void AddIngredienteToPizza(Ingrediente ingrediente, int pizzaId)
        {
            // Puedes agregar lógica aquí para asociar un ingrediente a una pizza específica
            ingrediente.Id = nextId++;
            ingrediente.PizzaId = pizzaId;
            Ingredientes.Add(ingrediente);
        }

        public void UpdateIngredientesForPizza(List<Ingrediente> ingredientes, int pizzaId)
        {
            // Puedes agregar lógica aquí para actualizar la lista de ingredientes asociada a una pizza específica
            // Puedes borrar todos los ingredientes asociados a la pizza y luego agregar los nuevos
            Ingredientes.RemoveAll(i => i.PizzaId == pizzaId);
            foreach (var ingrediente in ingredientes)
            {
                AddIngredienteToPizza(ingrediente, pizzaId);
            }
        }
    }
}
