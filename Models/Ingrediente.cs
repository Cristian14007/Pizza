namespace PizzaExample.Models;

using System.ComponentModel.DataAnnotations;
using System.Text;

public class Ingrediente
{

    public int IngredienteId { get; set; }
    public string Nombre { get; set; }
    public List<PizzaIngrediente> PizzaIngredientes { get; set; }
    /* [Key]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Origen { get; set; }

    //public int PizzaId { get; set; }

    [Required]
    public int? Calorias { get; set; } */


    // EF Core requiere un constructor sin parámetros
    public Ingrediente (){

    }

    public Ingrediente(int ingredienteid, string nombre){

        IngredienteId = ingredienteid;
        Nombre = nombre;
        
    }
}