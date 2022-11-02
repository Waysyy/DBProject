using Microsoft.AspNetCore.Mvc;
using project.Models;
using project.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CakesController : ControllerBase
    {
         
        private readonly ICakesServise cakesServise;

        public CakesController(ICakesServise cakesServise)
        {
            
            this.cakesServise = cakesServise;
        }

        // GET: api/<ConfectioneryController>
        [HttpGet]
        public ActionResult<List<Cakes>> Get()
        {
            
                return cakesServise.Get();
            
                
        }

        // GET api/<ConfectioneryController>/5
        [HttpGet("{id}")]
        public ActionResult<Cakes> Get(string id)
        {

            var cakes = cakesServise.Get(id); 
            if(cakes == null)
            {
                return NotFound($"Торт с ID = {id} не найден ");
            }
            return cakes;
        }

        // POST api/<ConfectioneryController>
        [HttpPost]
        public ActionResult<Cakes> Post([FromBody] Cakes cakes)
        {
            cakesServise.Create(cakes);
            return CreatedAtAction(nameof(Get), new {id = cakes.Id}, cakes);
        }

        // PUT api/<ConfectioneryController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Cakes cakes)
        {
            var existingCakes = cakesServise.Get(id);
            if (cakes == null)
            {
                return NotFound($"Торт с ID = {id} не найден ");
            }
            cakesServise.Update(id,cakes);
            return NoContent();
        }

        // DELETE api/<ConfectioneryController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var cakes = cakesServise.Get(id);
            if (cakes == null)
            {
                return NotFound($"Торт с ID = {id} не найден ");
            }
            cakesServise.Remove(cakes.Id);
            return Ok($"Торт с ID = {id} удален ");
        }
    }
}
