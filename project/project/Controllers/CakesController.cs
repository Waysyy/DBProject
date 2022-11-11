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


    [Route("api/[controller]")]
    [ApiController]
    public class CakesController : ControllerBase
    {
         
        private readonly ICakesServise cakesServise;

        TokenOperations tokenOperations = new TokenOperations();
        public CakesController(ICakesServise cakesServise)
        {
            
            this.cakesServise = cakesServise;
            
        }



        
        /*[Authorize(Roles ="admin")]
        [Authorize(AuthenticationSchemes = "Bearer")] */
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

            
            if (tokenOperations.GetGroup(Request.Headers.Values.ElementAt(6)) == true)
            {
                cakesServise.Create(cakes);
                return CreatedAtAction(nameof(Get), new { id = cakes.Id }, cakes);
            }
            else
                return NotFound($"У вас недостаточно прав");


        }

        // PUT api/<ConfectioneryController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Cakes cakes)
        {
            if (tokenOperations.GetGroup(Request.Headers.Values.ElementAt(6)) == true)
            {
                var existingCakes = cakesServise.Get(id);
                if (cakes == null)
                {
                    return NotFound($"Торт с ID = {id} не найден ");
                }
                cakesServise.Update(id, cakes);
                return NoContent();
            }
            else
                return NotFound($"У вас недостаточно прав");
        }

        // DELETE api/<ConfectioneryController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            if (tokenOperations.GetGroup(Request.Headers.Values.ElementAt(6)) == true)
            {
                var cakes = cakesServise.Get(id);
                if (cakes == null)
                {
                    return NotFound($"Торт с ID = {id} не найден ");
                }
                cakesServise.Remove(cakes.Id);
                return Ok($"Торт с ID = {id} удален ");
            }
            else
                return NotFound($"У вас недостаточно прав");
        }
    }
}
