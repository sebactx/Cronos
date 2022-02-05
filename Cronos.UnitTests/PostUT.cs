using Cronos.Api.Controllers;
using Cronos.Api.Data;
using Cronos.Api.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;

namespace Cronos.UnitTests
{
    public class PostUT
    {
        static PostController? controller;
        public PostUT()
        {
            ApiContext context = new ApiContext();
            controller = new PostController(context);
        }
        [Fact]
        public async Task T1_DeveTrazer3Inst�ncias()
        {
            if  (controller == null)
            {
                Assert.False(false, "Falha na API");
                return;
            }
            var result = await controller.Get();
            Assert.True(result != null && result is OkObjectResult r && r.Value != null);
        }
        [Fact]
        public static async Task T2_DeveTrazerInst�nciaInserida()
        {
            if (controller == null)
            {
                Assert.False(false, "Falha na API");
                return;
            }
            Post tm = new Post
            {
                Text = "Houve consenso sobre a estrat�gia e as t�ticas a adotar"
            };
            var result = await controller.PostAsync(tm);
            Assert.True(result != null && result is CreatedResult r && r.Value != null);
        }
        [Fact]
        public async Task T3_DeveTrazer4Inst�ncias()
        {
            if (controller == null)
            {
                Assert.False(false, "Falha na API");
                return;
            }
            await controller.PostAsync(new Post
            {
                Text = "Houve consenso sobre a estrat�gia e as t�ticas a adotar"
            });
            var result = await controller.Get();
            Assert.True(result != null && result is OkObjectResult r && r.Value != null &&
                r.Value is List<Post> tm && tm.Count == 4);
        }
        [Fact]
        public async Task T4_DeveTrazerPost2()
        {
            if (controller == null)
            {
                Assert.False(false, "Falha na API");
                return;
            }
            var result = await controller.GetByIdAsync(2);
            Assert.True(result != null && result is OkObjectResult r && r.Value != null &&
                r.Value is Post);
        }
    }
}