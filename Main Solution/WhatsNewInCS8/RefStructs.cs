using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNewInCS8
{
    class RefStructs
    {
        /*
         * Structs declared with the ref keyword cannot implement interfaces.
         * This rule also applies to readonly ref structs.
         */

        ref struct MyStruct /*: IDisposable*/   // it is an error to implement interfaces for ref structs.
        {

        }

        public static void Run()
        {
            Console.WriteLine($"Read the code for {typeof(RefStructs)} along with comments for details.");
        }
    }
}
