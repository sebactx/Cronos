using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cronos.Api.Data;
using Cronos.Api.Model;

namespace Cronos.Api.Controllers
{
    [Route("api/Post")]
    public class PostController : Controller
    {
        private readonly ApiContext apiContext;

        public PostController(ApiContext apiContext)
        {
            this.apiContext = apiContext;
        }

        // GET api/values  
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Post> items = await apiContext.GetPosts();
            return Ok(items);
        }

        [HttpGet]
        [Route("getbyid")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (apiContext.Posts == null)
                return NotFound();
            var item = await apiContext.Posts.FindAsync(id);
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Post item)
        {
            if (apiContext.Posts == null)
                return NotFound();
            Post newPost = new()
            {
                DateInsertion = item.DateInsertion,
                Text = item.Text
            };
            await apiContext.Posts.AddAsync(newPost);
            await apiContext.SaveChangesAsync();
            return Created($"/getbyid?id={item.Id}", item);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(Post item)
        {
            if (apiContext.Posts == null)
                return NotFound();
            var original = await apiContext.Posts.FindAsync(item.Id);
            if (original != null)
            {
                original.DateInsertion = item.DateInsertion;
                original.DateLastUpdate = DateTime.Today;
                original.Text = item.Text;
                apiContext.Posts.Update(original);
                await apiContext.SaveChangesAsync();
            }
            return NoContent();
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (apiContext.Posts == null)
                return NotFound();
            var item = await apiContext.Posts.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            apiContext.Posts.Remove(item);
            await apiContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
