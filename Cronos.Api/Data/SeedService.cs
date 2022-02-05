using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Collections.Generic;
using System.Linq;
using Cronos.Api.Model;

namespace Cronos.Api.Data
{
    static public class SeedService
    {
        static public void Load(ApiContext context)
        {
            if (context.Services == null)
                return;
            context.Services.Add(new Service() { Name = "Desenvolvimento de Lambda Function", TypeServ = ServType.Development });
            context.Services.Add(new Service() { Name = "Desenvolvimento de Mobile App", TypeServ = ServType.Development });
            context.Services.Add(new Service() { Name = "Avaliação de Marca", TypeServ = ServType.Marketing });
            context.Services.Add(new Service() { Name = "Reposicionamento de Produto", TypeServ = ServType.Marketing });
            context.Services.Add(new Service() { Name = "Harmonização Cores", TypeServ = ServType.UXDesign});
            context.Services.Add(new Service() { Name = "Melhoria Tempo de Resposta", TypeServ = ServType.UXDesign });
        }
    }
}
