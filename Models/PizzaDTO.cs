namespace PizzaExample.Models;

using System.ComponentModel.DataAnnotations;
public class PizzaDTO
{
    public int PizzaId { get; set; }
    public string Nombre { get; set; }
    public List<IngredienteDTO> Ingredientes  { get; set; }
}