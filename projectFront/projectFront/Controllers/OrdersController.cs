using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectFront.Models;
using projectFront.Services;
using System.Collections.Generic;

namespace projectFront.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {

        TokenOperations tokenOperations = new TokenOperations();
        
        public OrdersController() { }

        OrdersServise ordersServise = new OrdersServise();

        public OrdersController(OrdersServise ordersServise)
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
            if (tokenOperations.GetGroup() == true)
            {
                ordersServise.Create(orders);
                return CreatedAtAction(nameof(Get), new { id = orders.Id }, orders);
            }
            else
                return NotFound($"У вас недостаточно прав");
        }

        // PUT api/<ConfectioneryController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Orders orders)
        {
            if (tokenOperations.GetGroup() == true)
            {
                var existingOrders = ordersServise.Get(id);
                if (orders == null)
                {
                    return NotFound($"Заказ с ID = {id} не найден ");
                }
                ordersServise.Update(id, orders);
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
                var orders = ordersServise.Get(id);
                if (orders == null)
                {
                    return NotFound($"Заказ с ID = {id} не найден ");
                }
                ordersServise.Remove(orders.Id);
                return Ok("ok");
            }
            else
                return NotFound($"У вас недостаточно прав");
        }
    }
}
