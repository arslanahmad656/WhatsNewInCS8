using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNewInCS8
{
    class StaticLocalFunctions
    {
        public static void Run()
        {
            DemoStaticLocalFunctions();
            Console.WriteLine($"Read the code for {typeof(StaticLocalFunctions)} along with comments for details.");
        }

        /*
         * Local functions can be declared static. Static local functions can't capture the local variables hence
         * no closure is created.
         */
        static void DemoStaticLocalFunctions()
        {
            int a = 10;

            static void StaticLocalFunction()
            {
                // this method cannot access the variables local to the sorrounding method since this method is static.
            }

            void NonStaticLocalFunction()
            {
                int x = a;
                // this method can access the local variables and can create closures since this method is not static.
            }
        }
    }
}
