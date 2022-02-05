using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cronos.Api.Data;
using Cronos.Api.Model;

namespace Cronos.Api.Controllers
{
    [Route("api/TeamMember")]
    public class TeamMemberController : Controller
    {
        private readonly ApiContext apiContext;

        public TeamMemberController(ApiContext apiContext)
        {
            this.apiContext = apiContext;
        }

        // GET api/values  
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<TeamMember> items = await apiContext.GetTeamMembers();
            return Ok(items);
        }

        [HttpGet]
        [Route("getbyid")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (apiContext.TeamMembers == null)
                return NotFound();
            var item = await apiContext.TeamMembers.FindAsync(id);
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(TeamMember item)
        {
            if (apiContext.TeamMembers == null)
                return NotFound();
            await apiContext.TeamMembers.AddAsync(item);
            await apiContext.SaveChangesAsync();
            return Created($"/getbyid?id={item.Id}", item);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(TeamMember item)
        {
            if (apiContext.TeamMembers == null)
                return NotFound();
            var original = await apiContext.TeamMembers.FindAsync(item.Id);
            if  (original != null)
            {
                original.Name = item.Name;
                apiContext.TeamMembers.Update(original);
                await apiContext.SaveChangesAsync();
            }
            return NoContent();
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (apiContext.TeamMembers == null)
                return NotFound();
            var item = await apiContext.TeamMembers.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            apiContext.TeamMembers.Remove(item);
            await apiContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
