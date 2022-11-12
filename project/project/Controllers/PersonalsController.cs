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
    public class PersonalsController : Controller
    {
        private readonly IPersonalsServise personalsServise;
        TokenOperations tokenOperations = new TokenOperations();
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
                return NotFound($"Работник с ID = {id} не найден ");
            }
            return personals;
        }

       [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult<Personals> Post([FromBody] Personals personals)
        {
            if (tokenOperations.GetGroup(Request.Headers.Values.ElementAt(6)) == true)
            {
                personalsServise.Create(personals);
                return CreatedAtAction(nameof(Get), new { id = personals.Id }, personals);
            }
            else
                return NotFound($"У вас недостаточно прав");
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Personals personals)
        {
            if (tokenOperations.GetGroup(Request.Headers.Values.ElementAt(6)) == true)
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

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            if (tokenOperations.GetGroup(Request.Headers.Values.ElementAt(6)) == true)
            {
                var personals = personalsServise.Get(id);
                if (personals == null)
                {
                    return NotFound($"Работник с ID = {id} не найден ");
                }
                personalsServise.Remove(personals.Id);
                return Ok($"Работник с ID = {id} удален ");
            }
            else
                return NotFound($"У вас недостаточно прав");
        }
    }
}
