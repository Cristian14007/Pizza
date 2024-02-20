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
            return _context.Pizzas.FirstOrDefault(p => p.PizzaId == id);
        }

        public List<PizzaDTO> GetAll()
        {
            var pizzas = _context.Pizzas
        .Include(p => p.PizzaIngredientes)
            .ThenInclude(pi => pi.Ingrediente)
        .ToList();

    var pizzasDTO = pizzas.Select(p => new PizzaDTO
    {
        PizzaId = p.PizzaId,
        Nombre = p.Nombre,
        Ingredientes = p.PizzaIngredientes.Select(pi => new IngredienteDTO
        {
            IngredienteId = pi.Ingrediente.IngredienteId,
            Nombre = pi.Ingrediente.Nombre
        }).ToList()
    }).ToList();

    return pizzasDTO;
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