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
    public class ServiceTest
    {
        private static ServiceController controller = new ServiceController(new ApiContext());
        public static async Task Test1(string msg = "*** Services Pré-cadastrados ***")
        {
            System.Console.WriteLine(msg);
            var result = await controller.Get();
            if (result != null && result is OkObjectResult r && r.Value != null)
            {
                foreach(Service m in (System.Collections.Generic.List<Service>)r.Value)
                        System.Console.WriteLine(m.Name);
            }
            else
            System.Console.WriteLine($"Imprevisto: {result.GetType()}");
        }
        public static async Task Test2()
        {
            System.Console.WriteLine("*** Novo Service ***");
            Service tm = new Service
            {
                TypeServ = ServType.Marketing,
                Name = "Definir a verba para a próxima campanha"
            };
            var result = await controller.PostAsync(tm);
            if (result != null && result is CreatedResult r && r.Value != null)
            {
                if  (r.Value is Service m)
                    System.Console.WriteLine(m.Name);
                else
                    System.Console.WriteLine($"Resultado de Tipo Não Previsto: {r.Value.GetType()}");
            }
            else
                System.Console.WriteLine($"Imprevisto: {result.GetType()}");
            await Test1("Nova Lista de Services");
        }
        public static async Task Test3()
        {
            System.Console.WriteLine("*** Alteração do Nome do Segundo Serviço ***");
            Service tm = new Service
            {
                Id = 2,
                Name = "Desenvolvimento da plataforma para aplicativos móveis"
            };
            var result = await controller.PutAsync(tm);
            System.Console.WriteLine($"Retorno: {result.GetType()}");
            await Test1("Services com Textos Atualizados");
        }
        public static async Task Test4()
        {
            System.Console.WriteLine("*** Exclusão do Primeiro Service ***");
            var result = await controller.DeleteAsync(1);
            System.Console.WriteLine($"Retorno: {result.GetType()}");
            await Test1("Services Após Exclusão");
        }
    }
}
