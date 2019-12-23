using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsNewInCS8Core
{
    class IndicesAndRanges
    {
        public static void Run()
        {
            Demo();
            Console.WriteLine($"Read the code for {typeof(NullableReferenceTypes)} along with comments for details.");
        }

        static void Demo()
        {
            var words = new string[]
            {
                            // index from start    index from end
                "The",      // 0                   ^9
                "quick",    // 1                   ^8
                "brown",    // 2                   ^7
                "fox",      // 3                   ^6
                "jumped",   // 4                   ^5
                "over",     // 5                   ^4
                "the",      // 6                   ^3
                "lazy",     // 7                   ^2
                "dog"       // 8                   ^1
            };

            Console.WriteLine("From start:");
            Console.WriteLine(words[0]);
            Console.WriteLine(words[1]);
            Console.WriteLine(words[2]);
            Console.WriteLine(words[3]);
            Console.WriteLine(words[4]);
            Console.WriteLine(words[5]);
            Console.WriteLine(words[6]);
            Console.WriteLine(words[7]);
            Console.WriteLine(words[8]);

            Console.WriteLine();
            Console.WriteLine("From end:");
            //Console.WriteLine(words[^0]);
            Console.WriteLine(words[^1]);
            Console.WriteLine(words[^2]);
            Console.WriteLine(words[^3]);
            Console.WriteLine(words[^4]);
            Console.WriteLine(words[^5]);
            Console.WriteLine(words[^6]);
            Console.WriteLine(words[^7]);
            Console.WriteLine(words[^8]);
            Console.WriteLine(words[^9]);

            Console.WriteLine();
            var r1 = words[1..4]; // quick brown fox
            var r2 = words[^2..^0];   // lazy dog
            var r3 = words[..];   // The quick brown fox jumped over the lazy dog
            var r4 = words[..4];  // the quick brown fox
            var r5 = words[6..];  // the lazy dog
            try
            {
                var r6 = words[^2..^5];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType().FullName}: {ex.Message}");
            }

            var index = ^1;
            var range = 3..10;

            Console.WriteLine(index.GetType().FullName + "; " + index.GetType().Assembly.FullName);
            Console.WriteLine(range.GetType().FullName + "; " + range.GetType().Assembly.FullName);
        }
    }
}
