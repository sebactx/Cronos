using Cronos.Api.Controllers;
using Cronos.Api.Data;
using Cronos.Api.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;

namespace Cronos.UnitTests
{
    public class ServiceUT
    {
        static ServiceController? controller;
        public ServiceUT()
        {
            ApiContext context = new ApiContext();
            controller = new ServiceController(context);
        }
        [Fact]
        public async Task T1_DeveTrazer6Instâncias()
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
            Service tm = new Service
            {
                TypeServ = ServType.Marketing,
                Name = "Definir a verba para a próxima campanha"
            };
            var result = await controller.PostAsync(tm);
            Assert.True(result != null && result is CreatedResult r && r.Value != null);
        }
        [Fact]
        public async Task T3_DeveTrazer7Instâncias()
        {
            if (controller == null)
            {
                Assert.False(false, "Falha na API");
                return;
            }
            await controller.PostAsync(new Service
            {
                TypeServ = ServType.Marketing,
                Name = "Definir a verba para a próxima campanha"
            });
            var result = await controller.Get();
            Assert.True(result != null && result is OkObjectResult r && r.Value != null &&
                r.Value is List<Service> tm && tm.Count == 7);
        }
        [Fact]
        public async Task T4_DeveTrazerServiço2()
        {
            if (controller == null)
            {
                Assert.False(false, "Falha na API");
                return;
            }
            var result = await controller.GetByIdAsync(2);
            Assert.True(result != null && result is OkObjectResult r && r.Value != null &&
                r.Value is Service);
        }
    }
}