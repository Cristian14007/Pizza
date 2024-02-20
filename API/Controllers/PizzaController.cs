using PizzaExample.Models;
using PizzaExample.Business;
using Microsoft.AspNetCore.Mvc;

namespace PizzaExample.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private readonly IPizzaService _pizzaService;
    public PizzaController(IPizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }

    [HttpGet]
public ActionResult<List<PizzaDTO>> GetAll() =>
    _pizzaService.GetAll();

    [HttpGet]
    [Route("Id")]
public ActionResult<Pizza> Get(int id)
{
    var pizza = _pizzaService.Get(id);

    if(pizza == null)
        return NotFound();

    return pizza;
}

    [HttpPost]
public IActionResult Create(Pizza pizza)
{            
    _pizzaService.Add(pizza);
    return CreatedAtAction(nameof(Get), new { id = pizza.PizzaId }, pizza);
}
[HttpPut("{id}")]
public IActionResult Update(int id, Pizza pizza)
{
    if (id != pizza.PizzaId)
        return BadRequest();
           
    var existingPizza = _pizzaService.Get(id);
    if(existingPizza is null)
        return NotFound();
   
    _pizzaService.Update(pizza);           
   
    return NoContent();
}

    [HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var pizza = _pizzaService.Get(id);
   
    if (pizza is null)
        return NotFound();
       
    _pizzaService.Delete(id);
   
    return NoContent();
}
}