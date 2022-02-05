using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronos.Console
{
    public static class Tester
    {
        public static bool TesteCompleto = false;
        public static async Task Run()
        {
            await TeamMemberTest.Test1();
            await TeamMemberTest.Test2();
            await TeamMemberTest.Test3();
            await TeamMemberTest.Test4();
            await TeamMemberTest.Test5();
            System.Console.WriteLine();
            await PostTest.Test1();
            await PostTest.Test2();
            await PostTest.Test3();
            await PostTest.Test4();
            System.Console.WriteLine();
            await ServiceTest.Test1();
            await ServiceTest.Test2();
            await ServiceTest.Test3();
            await ServiceTest.Test4();
            Tester.TesteCompleto = true;
        }
    }
}
