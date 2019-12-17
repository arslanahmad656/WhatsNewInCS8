using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNewInCS8
{
    

    class Patterns
    {
        private class RGBColor
        {
            public RGBColor(uint red, uint green, uint blue)
            {
                Red = red;
                Green = green;
                Blue = blue;
            }

            public uint Red { get; set; }

            public uint Green { get; set; }

            public uint Blue { get; set; }

            public override string ToString() => $"({Red}, {Green}, {Blue})";
        }

        private enum Rainbow
        {
            Violet, Indigo, Blue, Green, Yellow, Orange, Red
        }

        public static void Run()
        {
            DemoPatternsWithSwitchExpression();
            Console.WriteLine($"Read the code for {typeof(Patterns)} along with comments for details.");
        }

        static void DemoPatternsWithSwitchExpression()
        {
            var colorFromRainbow1 = GetRGBColorFromRainbowColor(Rainbow.Indigo);
            var colorFromRainbow2 = GetRGBColorFromRainbowColorUsingStatement(Rainbow.Indigo);

            Console.WriteLine(colorFromRainbow1);
            Console.WriteLine(colorFromRainbow2);

            // Switch expression is now available as alternative to switch statement.
            // The switch expression differs from switch expression in a number of ways:
            //      Syntactically, the variable name comes before the switch keyword
            //      case : is replaced with =>
            //      break keyword is not mandatory to escape out of switch
            //      default keyword is replaced with a _ discard
            //      the bodies are expressions, not statements
            //      The whole expression is a single statment and needs to be terminated with a ;
            RGBColor GetRGBColorFromRainbowColor(Rainbow rainbowColor)
            {
                var rgbColor = rainbowColor switch
                {
                    Rainbow.Red => new RGBColor(0xFF, 0x00, 0x00),
                    Rainbow.Orange => new RGBColor(0xFF, 0x7F, 0x00),
                    Rainbow.Yellow => new RGBColor(0xFF, 0xFF, 0x00),
                    Rainbow.Green => new RGBColor(0x00, 0xFF, 0x00),
                    Rainbow.Blue => new RGBColor(0x00, 0x00, 0xFF),
                    Rainbow.Indigo => new RGBColor(0x4B, 0x00, 0x82),
                    Rainbow.Violet => new RGBColor(0x94, 0x00, 0xD3),
                    _ => throw new ArgumentOutOfRangeException(nameof(rainbowColor))
                };

                return rgbColor;
            }

            // The code in the following method does the exact same thing as in above function
            // but using the older switch statement. This is done to demonstrate the conciseness
            // of the switch expressions.
            RGBColor GetRGBColorFromRainbowColorUsingStatement(Rainbow rainbowColor)
            {
                RGBColor rgbColor;
                switch (rainbowColor)
                {
                    case Rainbow.Red:
                        rgbColor = new RGBColor(0xFF, 0x00, 0x00);
                        break;
                    case Rainbow.Orange:
                        rgbColor = new RGBColor(0xFF, 0x7F, 0x00);
                        break;
                    case Rainbow.Yellow:
                        rgbColor = new RGBColor(0xFF, 0xFF, 0x00);
                        break;
                    case Rainbow.Green:
                        rgbColor = new RGBColor(0x00, 0xFF, 0x00);
                        break;
                    case Rainbow.Blue:
                        rgbColor = new RGBColor(0x00, 0x00, 0xFF);
                        break;
                    case Rainbow.Indigo:
                        rgbColor = new RGBColor(0x4B, 0x00, 0x82);
                        break;
                    case Rainbow.Violet:
                        rgbColor = new RGBColor(0x94, 0x00, 0xD3);
                        break;
                    default:
                        throw new ArgumentException(message: "invalid enum value", paramName: nameof(rainbowColor));
                };

                return rgbColor;
            }
        }
    }
}
