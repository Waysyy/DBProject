using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projectFront.Models;
using projectFront.Services;
using System.Collections.Generic;
using System.Windows.Forms;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projectFront.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CakesController : ControllerBase
    {
         
      

        TokenOperations tokenOperations = new TokenOperations();
        

        public CakesController() { }

        CakesServise cakesServise = new CakesServise();

        public CakesController(CakesServise cakesServise)
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
                //MessageBox.Show("Вы ошиблись в ID, вывод может быть некорректен");
                return NotFound(null);
            }
            
            return cakes;
        }

        // POST api/<ConfectioneryController>
        [HttpPost]
        public ActionResult<Cakes> Post([FromBody] Cakes cakes)
        {
            
            if (tokenOperations.GetGroup() == true)
            {
                cakesServise.Create(cakes);
                return CreatedAtAction(nameof(Get), new { id = cakes.Id }, cakes);
            }
            else
                return NotFound(null);


        }

        // PUT api/<ConfectioneryController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Cakes cakes)
        {
            if (tokenOperations.GetGroup() == true)
            {
                var existingCakes = cakesServise.Get(id);
                if (cakes == null)
                {
                    return NotFound(null);
                }
                cakesServise.Update(id, cakes);
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
                var cakes = cakesServise.Get(id);
                if (cakes == null)
                {
                    return NotFound(null);
                }
                cakesServise.Remove(cakes.Id);
                return Ok("ok");
            }
            else
                return NotFound(null);
        }
    }
}
