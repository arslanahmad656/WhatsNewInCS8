using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsNewInCS8Core
{
    class NullableReferenceTypes
    {
        public static void Run()
        {
            Demo1();
            Console.WriteLine($"Read the code for {typeof(NullableReferenceTypes)} along with comments for details.");
        }

        static void Demo1()
        {
            /*
             *  When nullable annotation context is enabled, referencing a non-nullable reference type generates a warning.
             */

            string name = null; // warning
            string? name2 = null;   // no warning

            try
            {
                Console.WriteLine(name.Length);
                Console.WriteLine(name2.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception ignored!");
            }
        }
    }
}
