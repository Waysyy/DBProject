using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectFront.Models;
using projectFront.Services;
using System.Collections.Generic;

namespace projectFront.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : Controller
    {
        TokenOperations tokenOperations = new TokenOperations();
       

        public IngredientsController() { }

        IngredientsServise ingredientsServise = new IngredientsServise();

        public IngredientsController(IngredientsServise ingredientsServise)
        {
            this.ingredientsServise = ingredientsServise;
        }

        // GET: api/<ConfectioneryController>
        [HttpGet]
        public ActionResult<List<Ingredients>> Get()
        {
            return ingredientsServise.Get();
        }

        // GET api/<ConfectioneryController>/5
        [HttpGet("{id}")]
        public ActionResult<Ingredients> Get(string id)
        {
            var ingredients = ingredientsServise.Get(id);
            if (ingredients == null)
            {
                return NotFound($"Ингредиент с ID = {id} не найден ");
            }
            return ingredients;
        }

        // POST api/<ConfectioneryController>
        [HttpPost]
        public ActionResult<Ingredients> Post([FromBody] Ingredients ingredients)
        {
            if (tokenOperations.GetGroup() == true)
            {
                ingredientsServise.Create(ingredients);
                return CreatedAtAction(nameof(Get), new { id = ingredients.Id }, ingredients);
            }
            else
                return NotFound(null);
        }

        // PUT api/<ConfectioneryController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Ingredients ingredients)
        {
            if (tokenOperations.GetGroup() == true)
            {
                var existingIngredients = ingredientsServise.Get(id);
                if (ingredients == null)
                {
                    return NotFound($"Ингредиент с ID = {id} не найден ");
                }
                ingredientsServise.Update(id, ingredients);
                return NoContent();
            }
            else
                return NotFound(null);
        }

        // DELETE api/<ConfectioneryController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            if (tokenOperations.GetGroup() == true)
            {
                var ingredients = ingredientsServise.Get(id);
                if (ingredients == null)
                {
                    return NotFound($"Ингредиент с ID = {id} не найден ");
                }
                ingredientsServise.Remove(ingredients.Id);
                return Ok("ok");
            }
            else
                return NotFound(null);
        }
    }
}
