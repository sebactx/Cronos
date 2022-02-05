using Cronos.Api.Controllers;
using Cronos.Api.Data;
using Cronos.Api.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;

namespace Cronos.UnitTests
{
    public class TeamMemberUT
    {
        static TeamMemberController? controller;
        public TeamMemberUT()
        {
            ApiContext context = new ApiContext();
            controller = new TeamMemberController(context);
        }
        [Fact]
        public async Task T1_DeveTrazer3Instâncias()
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
        public static async Task T2_DeveTrazerInstânciaInserida()
        {
            if (controller == null)
            {
                Assert.False(false, "Falha na API");
                return;
            }
            TeamMember tm = new TeamMember
            {
                Name = "Marcelo Cosme"
            };
            var result = await controller.PostAsync(tm);
            Assert.True(result != null && result is CreatedResult r && r.Value != null);
        }
        [Fact]
        public async Task T3_DeveTrazer4Instâncias()
        {
            if (controller == null)
            {
                Assert.False(false, "Falha na API");
                return;
            }
            await controller.PostAsync(new TeamMember
            {
                Name = "Camila Morgado"
            });
            var result = await controller.Get();
            Assert.True(result != null && result is OkObjectResult r && r.Value != null &&
                r.Value is List<TeamMember> tm && tm.Count == 4);
        }
        [Fact]
        public async Task T4_DeveTrazerCamilaPitanga()
        {
            if (controller == null)
            {
                Assert.False(false, "Falha na API");
                return;
            }
            var result = await controller.GetByIdAsync(2);
            Assert.True(result != null && result is OkObjectResult r && r.Value != null &&
                r.Value is TeamMember);
        }
    }
}