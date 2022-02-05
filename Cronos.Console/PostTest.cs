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
    public class PostTest
    {
        private static PostController controller = new PostController(new ApiContext());
        public static async Task Test1(string msg = "*** Posts Pré-cadastrados ***")
        {
            System.Console.WriteLine(msg);
            var result = await controller.Get();
            if (result != null && result is OkObjectResult r && r.Value != null)
            {
                foreach(Post m in (System.Collections.Generic.List<Post>)r.Value)
                        System.Console.WriteLine(m.Text);
            }
            else
            System.Console.WriteLine($"Imprevisto: {result.GetType()}");
        }
        public static async Task Test2()
        {
            System.Console.WriteLine("*** Novo Post ***");
            Post tm = new Post
            {
                DateInsertion = DateTime.Today,
                Text = "Houve consenso sobre a estratégia e as táticas a adotar"
            };
            var result = await controller.PostAsync(tm);
            if (result != null && result is CreatedResult r && r.Value != null)
            {
                if  (r.Value is Post m)
                    System.Console.WriteLine(m.Text);
                else
                    System.Console.WriteLine($"Resultado de Tipo Não Previsto: {r.Value.GetType()}");
            }
            else
                System.Console.WriteLine($"Imprevisto: {result.GetType()}");
            await Test1("Nova Lista de Posts");
        }
        public static async Task Test3()
        {
            System.Console.WriteLine("*** Alteração do texto do segundo Post ***");
            Post tm = new Post
            {
                Id = 2,
                Text = "O MVP do aplicativo móvel precisa incorporar os novos recursos"
            };
            var result = await controller.PutAsync(tm);
            System.Console.WriteLine($"Retorno: {result.GetType()}");
            await Test1("Posts com Textos Atualizados");
        }
        public static async Task Test4()
        {
            System.Console.WriteLine("*** Exclusão do Primeiro Post ***");
            var result = await controller.DeleteAsync(1);
            System.Console.WriteLine($"Retorno: {result.GetType()}");
            await Test1("Posts Após Exclusão");
        }
    }
}
