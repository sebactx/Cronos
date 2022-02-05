using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Collections.Generic;
using System.Linq;
using Cronos.Api.Model;

namespace Cronos.Api.Data
{
    static public class SeedAdmin
    {
        static public void Load(ApiContext context)
        {
            if (context.Admins == null)
                return;
            context.Admins.Add(new AdminUser()
            { 
                Login = "admin",
                Name = "Adriana Esteves",
                Stamp = Guid.NewGuid().ToString(),
                Medusa = "q1w2e3r4"
            });

        }
    }
}
