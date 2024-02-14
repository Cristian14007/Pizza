namespace PizzaExample.Models;

using System.ComponentModel.DataAnnotations;
using System.Text;

public class Pizza
{

    [Key]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public bool IsGlutenFree { get; set; }

    //public List<Ingrediente> Ingredientes{get; set;}

// EF Core requiere un constructor sin parámetros
    public Pizza (){

    }

    public Pizza(int id, string name, bool isglutenfree){

        Id = id;
        Name = name;
        IsGlutenFree = isglutenfree;
    }

}