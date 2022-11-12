using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using project.Models;
using project.Services;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project.Controllers
{


    
    
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class CakesController : ControllerBase
    {
         
        private readonly ICakesServise cakesServise;

        TokenOperations tokenOperations = new TokenOperations();
        public CakesController(ICakesServise cakesServise)
        {
            
            this.cakesServise = cakesServise;
            
        }


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

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult<Cakes> Post([FromBody] Cakes cakes)
        {

                cakesServise.Create(cakes);
                return CreatedAtAction(nameof(Get), new { id = cakes.Id }, cakes);
            
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Cakes cakes)
        {
            
                var existingCakes = cakesServise.Get(id);
                if (cakes == null)
                {
                    return NotFound($"Торт с ID = {id} не найден ");
                }
                cakesServise.Update(id, cakes);
                return NoContent();
            
        }

        [Authorize(Roles = "admin")]
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
