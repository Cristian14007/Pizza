using PizzaExample.Models;

namespace PizzaExample.Data
{
    public interface IPizzaRepository
    {
        List<PizzaDTO> GetAll();
        void Add(Pizza pizza);
        Pizza Get(int id);
        void Update(Pizza pizza);
        void Delete (int id);


    }
}