using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNewInCS8
{
    enum Quadrant
    {
        First, Second, Third, Fourth, 
        Origin, 
        PositiveX, NegativeX, PositiveY, NegativeY
    }


    // readonly keyword on a struct member indicates that it cannot change a property of 'this' object.
    // readonly keyword (in this context) can only be used with the members of a struct (not class or interfaces)
    // Constructors cannot be marked as readonly

    // A struct can be made immutable by marking it with keyword readonly. After this, the struct cannot declare writable properties and all fileds must be declared
    // readonly.
    struct Point
    {
        // Auto implemented properties (only getters of course) are by default readonly.
        public double X { get; set; }

        // Properties can also be marked readonly on an accessor level i.e., if required, only one of the get or set can be marked readonly.
        public double Y { readonly get; set; }

        // A non-readonly property
        public double Displacement => Math.Sqrt(X * X + Y * Y);

        // A readonly property
        public readonly Quadrant Quadrant
        {
            get
            {
                if (X == 0 && Y > 0) return Quadrant.PositiveY;
                if (X == 0 && Y < 0) return Quadrant.NegativeY;
                if (X > 0 && Y == 0) return Quadrant.PositiveX;
                if (X < 0 && Y == 0) return Quadrant.NegativeX;
                if (X > 0 && Y > 0) return Quadrant.First;
                if (X > 0 && Y < 0) return Quadrant.Fourth;
                if (X < 0 && Y > 0) return Quadrant.Second;
                if (X < 0 && Y < 0) return Quadrant.Third;
                return Quadrant.Origin;
            }
        }

        public static readonly Point origin = new Point();

        public void MoveX(double units)
        {
            // It is a compiler error to make this method readonly since it is modifiying a property (or a field).
            this.X += units;
        }

        /// <summary>
        /// Returns the distance from another point.
        /// </summary>
        /// <param name="otherPoint"></param>
        /// <returns></returns>
        public readonly double GetDistance(Point otherPoint)
        {   
            return Math.Sqrt(Math.Pow(otherPoint.X - this.X, 2) + Math.Pow(otherPoint.Y - this.Y, 2));
        }

        public static ref readonly Point GetOrigin() => ref origin;

        public override readonly string ToString()
        {
            // Readonly keyword here defines the intent that we do not want to modify any of the properties in this method.

            // The use of a non-readonly property inside a readonly construct, results in a defensive copy of 'this'. The line below generates
            // a compiler warning on the usage of the property Displacement because it is not readonly. No warning is generated on the usage of Quadrant property
            // because it is readonly.
            // However, a warning also does not appear on the usage of auto-implemented properties X, Y. That is because, the auto-implemented properties are
            // by default readonly.
            return $"Point ({X}, {Y}) is {Displacement} units away from origin and lies in {Quadrant} quadrant.";
        }
    }


    class ReadonlyMembers
    {
        public static void Run()
        {
            DemoReadonlyRef();
            Console.WriteLine($"Read the code for {typeof(Point)} along with comments for details.");         
        }

        static void DemoReadonlyRef()
        {
            Console.WriteLine($"Point.origin (before changing): {Point.origin}");
            var point1 = Point.GetOrigin(); // notice the type! (it is not ref Point)
            Console.WriteLine($"Point through {nameof(point1)} (before changing): {point1}");
            point1.X = 11;
            Console.WriteLine($"Point through {nameof(point1)} (after changing): {point1}");
            Console.WriteLine($"Point.origin (after changing): {Point.origin}");
            var point2 = Point.GetOrigin();
            Console.WriteLine($"Point through {nameof(point2)}: {point2}");
        }
    }
}
