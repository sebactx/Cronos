// See https://aka.ms/new-console-template for more information
Console.WriteLine("Testes da Cronos API");
Cronos.Console.Tester.Run();
while (!Cronos.Console.Tester.TesteCompleto)
    ;
Console.WriteLine("Teste Completo");
Console.ReadLine();
