using Business_Logic_Layer.Entities;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Simple_E_Commerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductBLL _productBLL;
        public ProductsController()
        {
            _productBLL = new ProductBLL();
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productBLL.GetAll());
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!_productBLL.IsExists(id))
                return NotFound();

            return Ok(await _productBLL.GetById(id));
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            if (!_productBLL.IsExists(name))
                return NotFound();

            return Ok(await _productBLL.GetByName(name));
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductEntity product)
        {
            if (product is null)
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_productBLL.CategoryExists(product.CategoryId))
                return BadRequest("Category Not Found");
            _productBLL.Add(product);
            return Ok(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductEntity product)
        {
            if (!_productBLL.IsExists(id))
                return NotFound();
            if (!_productBLL.CategoryExists(product.CategoryId))
                return BadRequest("Category Not Found");
            if (id != product.Id)
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _productBLL.Update(product);
            return Ok(product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_productBLL.IsExists(id))
                return NotFound();
            var prod = await _productBLL.GetById(id);
            _productBLL.Delete(prod);
            return Ok(prod);
        }
    }
}
