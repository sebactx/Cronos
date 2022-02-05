using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Collections.Generic;
using System.Linq;
using Cronos.Api.Model;

namespace Cronos.Api.Data
{
    public class ApiContext:DbContext
    {
        public DbSet<TeamMember>? TeamMembers { get; set; }
        public DbSet<Service>? Services { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Category>? Categories { get; set; }

        public ApiContext()
        {
            SeedTeamMember.Load(this);
            SeedService.Load(this);
            SeedPost.Load(this);
            LoadCategories();
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
        public void LoadCategories()
        {
            if (Categories == null)
                return;
            Category category = new Category() { CategoryName = "Category1" };
            Categories.Add(category);
            category = new Category() { CategoryName = "Category2" };
            Categories.Add(category);
        }

        public async Task<List<Category>> GetCategories()
        {
            if (Categories == null)
                return new List<Category>();
            await Task.Delay(1);
            return Categories.Local.ToList<Category>();
        }
    }
}
