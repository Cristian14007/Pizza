using PizzaExample.Models;

namespace PizzaExample.Business
{
    public interface IPizzaService
    {
        List<PizzaDTO> GetAll();
        void Add(Pizza pizza);
        Pizza Get(int id);
        void Update(Pizza pizza);
        void Delete (int id);


    }
}