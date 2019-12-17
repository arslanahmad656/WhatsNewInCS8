using System;

namespace WhatsNewInCS8Core
{
    class Program
    {
        static void Main(string[] args)
        {
            DefaultInterfaceImplementation.Run();


            Pause();
        }

        static void Pause()
        {
            Console.Write($"Press any key to continue...");
            Console.ReadKey(false);
        }
    }
}
