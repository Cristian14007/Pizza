namespace PizzaExample.Models;

using System.ComponentModel.DataAnnotations;
using System.Text;

public class Pizza
{

    public int PizzaId { get; set; }
    public string Nombre { get; set; }
    public List<PizzaIngrediente> PizzaIngredientes { get; set; }

    /* [Key]
    public int PizzaId { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public bool IsGlutenFree { get; set; } */

    //public List<Ingrediente> Ingredientes{get; set;}

// EF Core requiere un constructor sin parámetros
    public Pizza (){

    }

    public Pizza(int pizzaid, string nombre){

        PizzaId = pizzaid;
        Nombre = nombre;
        
    }

}