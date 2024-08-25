using Business_Logic_Layer.Services;
using Business_Logic_Layer.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Simple_E_Commerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private CustomerBLL _customerBLL;
        public CustomersController()
        {
            _customerBLL = new CustomerBLL();
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customerBLL.GetAll());
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!_customerBLL.IsExists(id))
                return NotFound();
            return Ok(await _customerBLL.GetById(id));
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            if (!_customerBLL.IsExists(name))
                return NotFound();
            return Ok(await _customerBLL.GetByName(name));
        }

        // POST api/<CustomersController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerEntity customer)
        {
            if (customer is null)
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _customerBLL.Add(customer);
            return Ok(customer);

        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerEntity customer)
        {
            if (!_customerBLL.IsExists(id))
                return NotFound();
            if (id != customer.Id)
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _customerBLL.Update(customer);
            return Ok(customer);
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_customerBLL.IsExists(id))
                return NotFound();

            var cust = await _customerBLL.GetById(id);

            if (cust is null)
                return BadRequest(ModelState);

            _customerBLL.Delete(cust);

            return Ok(cust);
        }
    }
}
