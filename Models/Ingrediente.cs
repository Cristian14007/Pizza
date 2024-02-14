namespace PizzaExample.Models;

using System.ComponentModel.DataAnnotations;
using System.Text;

public class Ingrediente
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Origen { get; set; }

    //public int PizzaId { get; set; }

    [Required]
    public int? Calorias { get; set; }


    // EF Core requiere un constructor sin parámetros
    public Ingrediente (){

    }

    public Ingrediente(int id, string name, string origen, int calorias){

        Id = id;
        Name = name;
        Origen = origen;
        Calorias = calorias;
    }
}