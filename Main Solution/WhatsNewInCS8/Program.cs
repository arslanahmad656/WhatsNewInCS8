using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNewInCS8
{
    class Program
    {
        static void Main()
        {
            ReadonlyMembers.Run();
            Patterns.Run();
            AdvancedPatternMatching.Run();
            UsingDeclarations.Run();
            StaticLocalFunctions.Run();


            Pause();
        }

        static void Pause()
        {
            Console.Write($"Press any key to continue...");
            Console.ReadKey(false);
        }
    }
}
