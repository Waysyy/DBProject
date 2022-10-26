using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project.Models;
using project.Services;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : Controller
    {
        private readonly IClientsServise clientsServise;

        public ClientsController(IClientsServise clientsServise)
        {
            this.clientsServise = clientsServise;
        }

        // GET: api/<ConfectioneryController>
        [HttpGet]
        public ActionResult<List<Clients>> Get()
        {
            return clientsServise.Get();
        }

        // GET api/<ConfectioneryController>/5
        [HttpGet("{id}")]
        public ActionResult<Clients> Get(string id)
        {
            var clients = clientsServise.Get(id);
            if (clients == null)
            {
                return NotFound($"Торт с ID = {id} не найден ");
            }
            return clients;
        }

        // POST api/<ConfectioneryController>
        [HttpPost]
        public ActionResult<Clients> Post([FromBody] Clients clients)
        {
            clientsServise.Create(clients);
            return CreatedAtAction(nameof(Get), new { id = clients.Id }, clients);
        }

        // PUT api/<ConfectioneryController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Clients clients)
        {
            var existingClients = clientsServise.Get(id);
            if (clients == null)
            {
                return NotFound($"Торт с ID = {id} не найден ");
            }
            clientsServise.Update(id, clients);
            return NoContent();
        }

        // DELETE api/<ConfectioneryController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var clients = clientsServise.Get(id);
            if (clients == null)
            {
                return NotFound($"Торт с ID = {id} не найден ");
            }
            clientsServise.Remove(clients.Id);
            return Ok($"Торт с ID = {id} удален ");
        }
    }
}
