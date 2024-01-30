using PizzaExample.Models;

namespace PizzaExample.Data
{
    public interface IIngredientesRepository
    {
        List<Ingrediente> GetAll();
        void Add(Ingrediente ingrediente);
        Ingrediente Get(int id);
        void Update(Ingrediente ingrediente);
        void Delete(int id);

        List<Ingrediente> GetIngredientesByPizzaId(int pizzaId);
        void AddIngredienteToPizza(Ingrediente ingrediente, int pizzaId);
        void UpdateIngredientesForPizza(List<Ingrediente> ingredientes, int pizzaId);
    }
}