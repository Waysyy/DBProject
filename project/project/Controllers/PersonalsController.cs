using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project.Models;
using project.Services;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalsController : Controller
    {
        private readonly IPersonalsServise personalsServise;

        public PersonalsController(IPersonalsServise personalsServise)
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
                return NotFound($"Торт с ID = {id} не найден ");
            }
            return personals;
        }

        // POST api/<ConfectioneryController>
        [HttpPost]
        public ActionResult<Personals> Post([FromBody] Personals personals)
        {
            personalsServise.Create(personals);
            return CreatedAtAction(nameof(Get), new { id = personals.Id }, personals);
        }

        // PUT api/<ConfectioneryController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Personals personals)
        {
            var existingPersonals = personalsServise.Get(id);
            if (personals == null)
            {
                return NotFound($"Торт с ID = {id} не найден ");
            }
            personalsServise.Update(id, personals);
            return NoContent();
        }

        // DELETE api/<ConfectioneryController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var personals = personalsServise.Get(id);
            if (personals == null)
            {
                return NotFound($"Торт с ID = {id} не найден ");
            }
            personalsServise.Remove(personals.Id);
            return Ok($"Торт с ID = {id} удален ");
        }
    }
}
