using PizzaExample.Models;
using Microsoft.EntityFrameworkCore;

namespace PizzaExample.Data{
    
    public class IngredienteEFRepository : IIngredientesRepository{

        private readonly PizzaContext _context;

        public IngredienteEFRepository(PizzaContext context)
        {
            _context = context;
        }

        public void Add(Ingrediente ingrediente)
        {
            _context.Ingredientes.Add(ingrediente);

            SaveChanges();
        }

        public void Delete(int id)
        {
            var ingrediente = Get(id);
            if (ingrediente != null)
            {
                _context.Remove(ingrediente);
            }

            SaveChanges();
        }

        public Ingrediente Get(int id)
        {
            return _context.Ingredientes.FirstOrDefault(p => p.IngredienteId == id);
        }

        public List<Ingrediente> GetAll()
        {
            return _context.Ingredientes.ToList();
        }

        public void Update(Ingrediente ingrediente)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}