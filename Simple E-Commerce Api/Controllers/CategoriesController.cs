using Business_Logic_Layer.Entities;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Simple_E_Commerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private CategoryBLL _categoryBLL;
        public CategoriesController()
        {
            _categoryBLL = new CategoryBLL();
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryBLL.GetAll());
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!_categoryBLL.IsExists(id))
                return NotFound();

            return Ok(await _categoryBLL.GetById(id));
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            if (!_categoryBLL.IsExists(name))
                return NotFound();

            return Ok(await _categoryBLL.GetByName(name));
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post([FromBody] CategoryEntity category)
        {
            if (category is null)
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _categoryBLL.Add(category);
            return Ok(category);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryEntity category)
        {
            if (!_categoryBLL.IsExists(id))
                return NotFound();
            if (id != category.Id)
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _categoryBLL.Update(category);
            return Ok(category);

        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_categoryBLL.IsExists(id))
                return NotFound();
            var category = await _categoryBLL.GetById(id);
            if (category is null)
                return BadRequest(ModelState);
            _categoryBLL.Delete(category);
            return Ok(category);
        }
    }
}
