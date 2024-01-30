namespace PizzaExample.Models;

public class Pizza
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsGlutenFree { get; set; }

    public List<Ingrediente> Ingredientes{get; set;}
}