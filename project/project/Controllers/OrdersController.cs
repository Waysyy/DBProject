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
    public class OrdersController : Controller
    {
        private readonly IOrdersServise ordersServise;
        TokenOperations tokenOperations = new TokenOperations();
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

       [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult<Orders> Post([FromBody] Orders orders)
        {
            
                ordersServise.Create(orders);
                return CreatedAtAction(nameof(Get), new { id = orders.Id }, orders);
            
        }

        [Authorize(Roles = "admin")]
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

        [Authorize(Roles = "admin")]
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
