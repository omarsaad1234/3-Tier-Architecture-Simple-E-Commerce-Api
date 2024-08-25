using Business_Logic_Layer.Entities;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Simple_E_Commerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private OrderItemBLL _orderItemBLL;
        public OrderItemsController()
        {
            _orderItemBLL=new OrderItemBLL();
        }
        // GET: api/<OrderItemsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderItemBLL.GetAll());
        }

        // GET api/<OrderItemsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!_orderItemBLL.IsExists(id))
                return NotFound();

            return Ok(await _orderItemBLL.GetById(id));
        }
        [HttpGet("GetByOrderId")]
        public async Task<IActionResult> GetByOrderId(int orderId)
        {
            if (!_orderItemBLL.OrderExists(orderId))
                return NotFound();

            return Ok(await _orderItemBLL.GetByOrderId(orderId));
        }

        // POST api/<OrderItemsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderItemEntity orderItem)
        {
            if (orderItem is null)
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_orderItemBLL.OrderExists(orderItem.OrderId))
                return BadRequest("Wrong Order Id");
            if (!_orderItemBLL.ProductExists(orderItem.ProductId))
                return BadRequest("Wrong Product Id");
            await _orderItemBLL.Add(orderItem);
            return Ok(orderItem);
        }

        // PUT api/<OrderItemsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OrderItemEntity orderItem)
        {
            if (!_orderItemBLL.IsExists(id))
                return NotFound();
            if (id != orderItem.Id)
                return BadRequest(ModelState);
            if (orderItem is null)
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_orderItemBLL.OrderExists(orderItem.OrderId))
                return BadRequest("Wrong Order Id");
            if (!_orderItemBLL.ProductExists(orderItem.ProductId))
                return BadRequest("Wrong Product Id");
            await _orderItemBLL.Update(orderItem);
            return Ok(orderItem);
        }

        // DELETE api/<OrderItemsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_orderItemBLL.IsExists(id))
                return NotFound();
            var orderItem = await _orderItemBLL.GetById(id);
            await _orderItemBLL.Delete(orderItem);
            return Ok(orderItem);
        }
    }
}
