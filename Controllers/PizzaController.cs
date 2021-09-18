using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {

        }

        //Get all action
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();        

        //Get by Id action
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);
            if (pizza == null)
                return NotFound();

            return pizza;
        }

        //Post action
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
        }       

        //Put action
        [HttpPut("{id}")]
        public IActionResult Put(int id, Pizza pizza)
        {
            if (id != pizza.Id)
                return BadRequest();
            
            var existingPizza = PizzaService.Get(id);
            if (existingPizza is null)
                return NotFound();

            PizzaService.Update(pizza);

            return NoContent();
        }

        //Delete action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null)
                NotFound();

            PizzaService.Delete(id);

            return NoContent();
        }
    }
}