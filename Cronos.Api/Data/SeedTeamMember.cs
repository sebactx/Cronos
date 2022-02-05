using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Collections.Generic;
using System.Linq;
using Cronos.Api.Model;

namespace Cronos.Api.Data
{
    static public class SeedTeamMember
    {
        static public void Load(ApiContext context)
        {
            if (context.TeamMembers == null)
                return;
            context.TeamMembers.Add(new TeamMember() { Name = "Adriana Esteves" });
            context.TeamMembers.Add(new TeamMember() { Name = "Camila Pitanga" });
            context.TeamMembers.Add(new TeamMember() { Name = "Regina Casé" });
        }
    }
}
