using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project.Models;
using project.Services;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IOrdersServise ordersServise;

        public OrdersController(IOrdersServise ordersServise)
        {
            this.ordersServise = ordersServise;
        }

        // GET: api/<ConfectioneryController>
        [HttpGet]
        public ActionResult<List<Orders>> Get()
        {
            return ordersServise.Get();
        }

        // GET api/<ConfectioneryController>/5
        [HttpGet("{id}")]
        public ActionResult<Orders> Get(string id)
        {
            var orders = ordersServise.Get(id);
            if (orders == null)
            {
                return NotFound($"Заказ с ID = {id} не найден ");
            }
            return orders;
        }

        // POST api/<ConfectioneryController>
        [HttpPost]
        public ActionResult<Orders> Post([FromBody] Orders orders)
        {
            ordersServise.Create(orders);
            return CreatedAtAction(nameof(Get), new { id = orders.Id }, orders);
        }

        // PUT api/<ConfectioneryController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Orders orders)
        {
            var existingOrders = ordersServise.Get(id);
            if (orders == null)
            {
                return NotFound($"Заказ с ID = {id} не найден ");
            }
            ordersServise.Update(id, orders);
            return NoContent();
        }

        // DELETE api/<ConfectioneryController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var orders = ordersServise.Get(id);
            if (orders == null)
            {
                return NotFound($"Заказ с ID = {id} не найден ");
            }
            ordersServise.Remove(orders.Id);
            return Ok($"Заказ с ID = {id} удален ");
        }
    }
}
