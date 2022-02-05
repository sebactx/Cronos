using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cronos.Api.Data;
using Cronos.Api.Model;

namespace Cronos.Api.Controllers
{
    [Route("api/Service")]
    public class ServiceController : Controller
    {
        private readonly ApiContext apiContext;

        public ServiceController(ApiContext apiContext)
        {
            this.apiContext = apiContext;
        }

        // GET api/values  
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Service> items = await apiContext.GetServices();
            return Ok(items);
        }

        [HttpGet]
        [Route("getbyid")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (apiContext.Services == null)
                return NotFound();
            var item = await apiContext.Services.FindAsync(id);
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Service item)
        {
            if (apiContext.Services == null)
                return NotFound();
            await apiContext.Services.AddAsync(item);
            await apiContext.SaveChangesAsync();
            return Created($"/getbyid?id={item.Id}", item);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(Service item)
        {
            if (apiContext.Services == null)
                return NotFound();
            apiContext.Services.Update(item);
            await apiContext.SaveChangesAsync();
            return NoContent();
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (apiContext.Services == null)
                return NotFound();
            var item = await apiContext.Services.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            apiContext.Services.Remove(item);
            await apiContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
