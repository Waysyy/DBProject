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
    public class ClientsController : Controller
    {
        private readonly IClientsServise clientsServise;
        TokenOperations tokenOperations = new TokenOperations();
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
                return NotFound($"Клиент с ID = {id} не найден ");
            }
            return clients;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult<Clients> Post([FromBody] Clients clients)
        {
            if (tokenOperations.GetGroup(Request.Headers.Values.ElementAt(6)) == true)
            {
                clientsServise.Create(clients);
                return CreatedAtAction(nameof(Get), new { id = clients.Id }, clients);
            }
            else
                return NotFound($"У вас недостаточно прав");
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Clients clients)
        {
            if (tokenOperations.GetGroup(Request.Headers.Values.ElementAt(6)) == true)
            {
                var existingClients = clientsServise.Get(id);
                if (clients == null)
                {
                    return NotFound($"Клиент с ID = {id} не найден ");
                }
                clientsServise.Update(id, clients);
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
                var clients = clientsServise.Get(id);
                if (clients == null)
                {
                    return NotFound($"Клиент с ID = {id} не найден ");
                }
                clientsServise.Remove(clients.Id);
                return Ok($"Клиент с ID = {id} удален ");
            }
            else
                return NotFound($"У вас недостаточно прав");
        }
    }
}
