using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectFront.Models;
using projectFront.Services;
using System.Collections.Generic;

namespace projectFront.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalsController : Controller
    {
        
        TokenOperations tokenOperations = new TokenOperations();
       
        public PersonalsController() { }

        PersonalsServise personalsServise = new PersonalsServise();

        public PersonalsController(PersonalsServise personalsServise)
        {
            this.personalsServise = personalsServise;
        }

        // GET: api/<ConfectioneryController>
        [HttpGet]
        public ActionResult<List<Personals>> Get()
        {
            return personalsServise.Get();
        }

        // GET api/<ConfectioneryController>/5
        [HttpGet("{id}")]
        public ActionResult<Personals> Get(string id)
        {
            var personals = personalsServise.Get(id);
            if (personals == null)
            {
                return NotFound($"Работник с ID = {id} не найден ");
            }
            return personals;
        }

        // POST api/<ConfectioneryController>
        [HttpPost]
        public ActionResult<Personals> Post([FromBody] Personals personals)
        {
            if (tokenOperations.GetGroup() == true)
            {
                personalsServise.Create(personals);
                return CreatedAtAction(nameof(Get), new { id = personals.Id }, personals);
            }
            else
                return NotFound($"У вас недостаточно прав");
        }

        // PUT api/<ConfectioneryController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Personals personals)
        {
            if (tokenOperations.GetGroup() == true)
            {
                var existingPersonals = personalsServise.Get(id);
                if (personals == null)
                {
                    return NotFound($"Работник с ID = {id} не найден ");
                }
                personalsServise.Update(id, personals);
                return NoContent();
            }
            else
                return NotFound($"У вас недостаточно прав");
        }

        // DELETE api/<ConfectioneryController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            if (tokenOperations.GetGroup() == true)
            {
                var personals = personalsServise.Get(id);
                if (personals == null)
                {
                    return NotFound($"Работник с ID = {id} не найден ");
                }
                personalsServise.Remove(personals.Id);
                return Ok("ok");
            }
            else
                return NotFound($"У вас недостаточно прав");
        }
    }
}
