namespace PizzaExample.Models;

public class Ingrediente
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Origen { get; set; }

    public int PizzaId { get; set; }
    public int? Calorias { get; set; }
}