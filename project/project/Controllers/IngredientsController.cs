using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project.Models;
using project.Services;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : Controller
    {
        private readonly IIngredientsServise ingredientsServise;

        public IngredientsController(IIngredientsServise ingredientsServise)
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
            ingredientsServise.Create(ingredients);
            return CreatedAtAction(nameof(Get), new { id = ingredients.Id }, ingredients);
        }

        // PUT api/<ConfectioneryController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Ingredients ingredients)
        {
            var existingIngredients = ingredientsServise.Get(id);
            if (ingredients == null)
            {
                return NotFound($"Ингредиент с ID = {id} не найден ");
            }
            ingredientsServise.Update(id, ingredients);
            return NoContent();
        }

        // DELETE api/<ConfectioneryController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var ingredients = ingredientsServise.Get(id);
            if (ingredients == null)
            {
                return NotFound($"Ингредиент с ID = {id} не найден ");
            }
            ingredientsServise.Remove(ingredients.Id);
            return Ok($"Ингредиент с ID = {id} удален ");
        }
    }
}
