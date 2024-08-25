using Business_Logic_Layer.Entities;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Simple_E_Commerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private OrderBLL _orderBLL;
        public OrdersController()
        {
            _orderBLL = new OrderBLL();
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderBLL.GetAll());
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!_orderBLL.IsExists(id))
                return NotFound();

            return Ok(await _orderBLL.GetById(id));
        }
        [HttpGet("GetByCustomerName")]
        public async Task<IActionResult> GetByCustomerName(string name)
        {
            if (!_orderBLL.CustomerExists(name))
                return NotFound();

            return Ok(await _orderBLL.GetByCustomerName(name));
        }

        // POST api/<OrdersController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderEntity order)
        {
            if (order is null)
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_orderBLL.CustomerExists(order.CustomerId))
                return BadRequest("Customer Doesn't Exist");

            _orderBLL.Add(order);
            return Ok(order);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OrderEntity order)
        {
            if (!_orderBLL.IsExists(id))
                return NotFound();
            if (id != order.Id)
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_orderBLL.CustomerExists(order.CustomerId))
                return BadRequest(ModelState);
            await _orderBLL.Update(order);
            return Ok(order);
        }


        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_orderBLL.IsExists(id))
                return NotFound();
            var order = await _orderBLL.GetById(id);
            _orderBLL.Delete(order);
            return Ok(order);
        }
    }
}
