using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Collections.Generic;
using System.Linq;
using Cronos.Api.Model;
using Microsoft.AspNetCore.Identity;

namespace Cronos.Api.Data
{
    public class ApiContext:DbContext
    {
        public DbSet<TeamMember>? TeamMembers { get; set; }
        public DbSet<Service>? Services { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<IdentityUser>? Admins { get; set; }

        public ApiContext()
        {
            SeedTeamMember.Load(this);
            SeedService.Load(this);
            SeedPost.Load(this);
            if  (Admins != null)
                Admins.Add(new IdentityUser()
                {
                    UserName = "admin",
                    SecurityStamp = Guid.NewGuid().ToString()
                });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("db");
            base.OnConfiguring(optionsBuilder);
        }
        public async Task<List<TeamMember>> GetTeamMembers()
        {
            if (TeamMembers == null)
                return new List<TeamMember>();
            await Task.Delay(1);
            return TeamMembers.Local.ToList<TeamMember>();
        }
        public async Task<List<Service>> GetServices()
        {
            if (Services == null)
                return new List<Service>();
            await Task.Delay(1);
            return Services.Local.ToList<Service>();
        }
        public async Task<List<Post>> GetPosts()
        {
            if (Posts == null)
                return new List<Post>();
            await Task.Delay(1);
            return Posts.Local.ToList<Post>();
        }
        public List<IdentityUser> GetAdmins()
        {
            if (Admins == null)
                return new List<IdentityUser>();
            return Admins.Local.ToList<IdentityUser>();
        }
    }
}
