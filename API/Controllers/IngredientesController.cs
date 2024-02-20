using PizzaExample.Models;
using PizzaExample.Business;
using Microsoft.AspNetCore.Mvc;

namespace PizzaExample.Controllers;

[ApiController]
[Route("[controller]")]
public class IngredientesController : ControllerBase
{
    private readonly IIngredienteService _ingredienteService;
    public IngredientesController(IIngredienteService ingredienteService)
    {
        _ingredienteService = ingredienteService;
    }

    [HttpGet]
    public ActionResult<List<Ingrediente>> GetAll() =>
    _ingredienteService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Ingrediente> Get(int id)
    {
        var ingrediente = _ingredienteService.Get(id);

        if (ingrediente == null)
            return NotFound();

        return ingrediente;
    }

    [HttpPost]
    public IActionResult Create(Ingrediente ingrediente)
    {
        _ingredienteService.Add(ingrediente);
        return CreatedAtAction(nameof(Get), new { id = ingrediente.IngredienteId }, ingrediente);
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, Ingrediente ingrediente)
    {
        if (id != ingrediente.IngredienteId)
            return BadRequest();

        var existingIngredient = _ingredienteService.Get(id);
        if (existingIngredient is null)
            return NotFound();

        _ingredienteService.Update(ingrediente);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var ingrediente = _ingredienteService.Get(id);

        if (ingrediente is null)
            return NotFound();

        _ingredienteService.Delete(id);

        return NoContent();
    }
}