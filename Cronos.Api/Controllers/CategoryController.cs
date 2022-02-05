using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cronos.Api.Data;
using Cronos.Api.Model;

namespace Cronos.Api.Controllers
{
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        private readonly ApiContext apiContext;

        public CategoryController(ApiContext apiContext)
        {
            this.apiContext = apiContext;
        }

        // GET api/values  
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Category> items = await apiContext.GetCategories();
            return Ok(items);
        }

        [HttpGet]
        [Route("getbyid")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (apiContext.Categories == null)
                return NotFound();
            var item = await apiContext.Categories.FindAsync(id);
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Category item)
        {
            if (apiContext.Categories == null)
                return NotFound();
            await apiContext.Categories.AddAsync(item);
            await apiContext.SaveChangesAsync();
            return Created($"/getbyid?id={item.Id}", item);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(Category item)
        {
            if (apiContext.Categories == null)
                return NotFound();
            apiContext.Categories.Update(item);
            await apiContext.SaveChangesAsync();
            return NoContent();
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (apiContext.Categories == null)
                return NotFound();
            var item = await apiContext.Categories.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            apiContext.Categories.Remove(item);
            await apiContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
