using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Collections.Generic;
using System.Linq;
using Cronos.Api.Model;

namespace Cronos.Api.Data
{
    static public class SeedPost
    {
        static public void Load(ApiContext context)
        {
            if (context.Posts == null)
                return;
            context.Posts.Add(new Post()
            { 
                DateInsertion = DateTime.Today.AddDays(-90),
                Text = "Cliente solicitou revisão da proposta. Espera menor prazo, menor custo e mais qualidade"
            });
            context.Posts.Add(new Post()
            {
                DateInsertion = DateTime.Today.AddDays(-20),
                Text = "O MVP do aplicativo móvel precisa rodar apenas nas versões mais recentes dos dispositivos"
            });
            context.Posts.Add(new Post()
            {
                DateInsertion = DateTime.Today.AddDays(-5),
                Text = "A migração para cloud aguarda apenas a definição: se Azure, AWS ou Google Cloud"
            });
        }
    }
}
