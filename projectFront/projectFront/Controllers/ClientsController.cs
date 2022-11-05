using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectFront.Models;
using projectFront.Services;
using System.Collections.Generic;

namespace projectFront.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : Controller
    {
        TokenOperations tokenOperations = new TokenOperations();
      

        public ClientsController() { }

        ClientsServise clientsServise = new ClientsServise();

        public ClientsController(ClientsServise clientsServise)
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

        // POST api/<ConfectioneryController>
        [HttpPost]
        public ActionResult<Clients> Post([FromBody] Clients clients)
        {
            if (tokenOperations.GetGroup() == true)
            {
                clientsServise.Create(clients);
                return CreatedAtAction(nameof(Get), new { id = clients.Id }, clients);
            }
            else
                return NotFound($"У вас недостаточно прав");
        }

        // PUT api/<ConfectioneryController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Clients clients)
        {
            if (tokenOperations.GetGroup() == true)
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

        // DELETE api/<ConfectioneryController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            if (tokenOperations.GetGroup() == true)
            {
                var clients = clientsServise.Get(id);
                if (clients == null)
                {
                    return NotFound($"Клиент с ID = {id} не найден ");
                }
                clientsServise.Remove(clients.Id);
                return Ok("ok");
            }
            else
                return NotFound($"У вас недостаточно прав");
        }
    }
}
