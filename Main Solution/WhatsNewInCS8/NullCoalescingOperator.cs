using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNewInCS8
{
    // Null-Coalescing assignment operator assigns the value at the right to the left hand side operand only if the operand at the left side is null.
    class NullCoalescingOperator
    {
        public static void Run()
        {
            Demo();
            Console.WriteLine($"Read the code for {typeof(NullCoalescingOperator)} along with comments for details.");
        }

        static void Demo()
        {
            int? x = 11;
            int? y = null;

            x ??= 13;   // 13 is not assigned to x since x is not null
            y ??= 15;   // y gets assigned 15 since it is null

            Console.WriteLine(x);
            Console.WriteLine(y);
        }
    }
}
