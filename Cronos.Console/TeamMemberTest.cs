using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cronos.Api.Controllers;
using Cronos.Api.Data;
using Cronos.Api.Model;
using Microsoft.AspNetCore.Mvc;


namespace Cronos.Console
{
    public class TeamMemberTest
    {
        private static TeamMemberController controller = new TeamMemberController(new ApiContext());
        public static async Task Test1(string msg = "*** Membros da Equipe Pré-cadastrados ***")
        {
            System.Console.WriteLine(msg);
            var result = await controller.Get();
            if (result != null && result is OkObjectResult r && r.Value != null)
            {
                foreach(TeamMember m in (System.Collections.Generic.List<TeamMember>)r.Value)
                        System.Console.WriteLine(m.Name);
            }
            else
            System.Console.WriteLine($"Imprevisto: {result.GetType()}");
        }
        public static async Task Test2()
        {
            System.Console.WriteLine("*** Cadastro de Novo Membro ***");
            TeamMember tm = new TeamMember
            {
                Name = "Marcelo Cosme"
            };
            var result = await controller.PostAsync(tm);
            if (result != null && result is CreatedResult r && r.Value != null)
            {
                if  (r.Value is TeamMember m)
                    System.Console.WriteLine(m.Name);
                else
                    System.Console.WriteLine($"Resultado de Tipo Não Previsto: {r.Value.GetType()}");
            }
            else
                System.Console.WriteLine($"Imprevisto: {result.GetType()}");
            await Test1("Membros Depois da Entrada do Marcelo Cosme");
        }
        public static async Task Test3()
        {
            System.Console.WriteLine("*** Alteração do nome da Camila Pitanga ***");
            TeamMember tm = new TeamMember
            {
                Id = 2,
                Name = "Camila Jaboticaba"
            };
            var result = await controller.PutAsync(tm);
            System.Console.WriteLine($"Retorno: {result.GetType()}");
            await Test1("Membros Com Nomes Atualizados");
        }
        public static async Task Test4()
        {
            System.Console.WriteLine("*** Exclusão da Adriana Esteves ***");
            var result = await controller.DeleteAsync(1);
            System.Console.WriteLine($"Retorno: {result.GetType()}");
            await Test1("Membros Após Exclusão da Adriana");
        }
        public static async Task Test5()
        {
            System.Console.WriteLine("*** Busca por Id ***");
            var result = await controller.GetByIdAsync(2);
            if  (result is OkObjectResult r && r.Value is TeamMember m)
                System.Console.WriteLine($"Id 2: {m.Name}");
        }
    }
}
