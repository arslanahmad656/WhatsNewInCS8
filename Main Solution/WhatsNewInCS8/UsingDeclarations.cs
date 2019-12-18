using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNewInCS8
{
    class MyClass : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Object is being disposed.");
        }
    }

    class UsingDeclarations
    {
        public static void Run()
        {
            DemoUsing();
            Console.WriteLine($"Read the code for {typeof(UsingDeclarations)} along with comments for details.");
        }

        static void DemoUsing()
        {
            DemoUsingDeclaration();
            DemoUsingStatememt();

            static void DemoUsingDeclaration()
            {
                // This is a using declaration (as opposed to the older using statement)
                // A variable that is declared with a using declaration, will be disposed (provided it is a disposable, of course)
                // at the end of the enclosing block.
                // No using block (a new scope for which the disposable remains alive) is created
                using var disposable = new MyClass();

                Console.WriteLine("Method runing...");

                // The disposable object will be disposed on returning from the function since the scope ends here
            }

            // The following method demonstrates the older using statement for the sake of comparing it with the newer using statement.
            static void DemoUsingStatememt()
            {
                using (var disposable = new MyClass())
                {
                    Console.WriteLine("Inside using block...");
                    // the disposable will be disposed here
                }

                Console.WriteLine("Method runing...");
            }
        }
    }
}
