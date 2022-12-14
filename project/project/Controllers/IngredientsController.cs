using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project.Models;
using project.Services;

namespace project.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class IngredientsController : Controller
    {
        private readonly IIngredientsServise ingredientsServise;
        TokenOperations tokenOperations = new TokenOperations();
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

       [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult<Ingredients> Post([FromBody] Ingredients ingredients)
        {
            
                ingredientsServise.Create(ingredients);
                return CreatedAtAction(nameof(Get), new { id = ingredients.Id }, ingredients);
            
        }

        [Authorize(Roles = "admin")]
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

        [Authorize(Roles = "admin")]
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
