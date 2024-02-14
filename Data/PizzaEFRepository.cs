using PizzaExample.Models;
using Microsoft.EntityFrameworkCore;

namespace PizzaExample.Data{
    
    public class PizzaEFRepository : IPizzaRepository{

        private readonly PizzaContext _context;

        public PizzaEFRepository(PizzaContext context)
        {
            _context = context;
        }

        public void Add(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            SaveChanges();
        }

        public void Delete(int id)
        {
            var pizza = Get(id);
            if (pizza != null)
            {
                _context.Remove(pizza);
            }

            SaveChanges();

        }

        public Pizza Get(int id)
        {
            return _context.Pizzas.FirstOrDefault(p => p.Id == id);
        }

        public List<Pizza> GetAll()
        {
            return _context.Pizzas.ToList();
        }

        public void Update(Pizza pizza)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}