using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNewInCS8
{
    /*
     * Scenario:
     *      Consider a major metropolitan area that is using tolls and peak time pricing to manage traffic.
     *      You write an application that calculates tolls for a vehicle based on its type. Later enhancements
     *      incorporate pricing based on the number of occupants in the vehicle. Further enhancements add 
     *      pricing based on the time and the day of the week.
     *      
     */

    // In order to model the above mentioned scenario, some classes are defined as:
    class Car
    {
        public int Passengers { get; set; }
    }

    class DeliveryTruck
    {
        public int GrossWeightClass { get; set; }
    }

    class Taxi
    {
        public int Fares { get; set; }
    }

    class Bus
    {
        public int Capacity { get; set; }
        public int Riders { get; set; }
    }

    // The following is the application class that can demonstrate the scenario:
    class AdvancedPatternMatching
    {
        public static void Run()
        {
            DemoScenario1();
            DemoScenario2();

            Console.WriteLine($"Read the code for {typeof(AdvancedPatternMatching)} along with comments for details.");
        }

        static void DemoScenario1()
        {
            /*
             * Toll calculation scanerio 1:
             *  Toll is calculated on the basis of the vehicle type:
             *      A Car is Rs50.00.
             *      A Taxi is Rs100.00.
             *      A Bus is Rs1000.00.
             *      A DeliveryTruck is Rs2500.00
             *
            */
            var carPrice = CalculateToll(new Car { Passengers = 10 });
            Console.WriteLine($"{carPrice:C}");

            var tructPrice = CalculateToll(new DeliveryTruck { GrossWeightClass = 1000 });
            Console.WriteLine($"{tructPrice:C}");

            try
            {
                var stringPrice = CalculateToll(new StringBuilder());
                Console.WriteLine($"{stringPrice:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType()}: {ex.Message}");
            }

            try
            {
                var nullPrice = CalculateToll(null);
                Console.WriteLine($"{nullPrice:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType()}: {ex.Message}");
            }
            
            static decimal CalculateToll(object vehicle)
            {
                // Pattern is matched on type of object
                var price = vehicle switch
                {
                    Car c => 50.00M,
                    Taxi t => 100.00M,
                    Bus b => 1000.00M,
                    DeliveryTruck t => 2500.00M,
                    // {} represents any non-null object. This arm must come last since it can match any type.
                    { } => throw new ArgumentOutOfRangeException(nameof(vehicle), $"Unknown vehicle type {vehicle.GetType()}"),
                    null => throw new ArgumentNullException(nameof(vehicle))
                };

                return price;
            }
        }

        static void DemoScenario2()
        {
            /*
             * The toll authority wants to encourage vehicles to travel at maximum capacity. They've decided to 
             * charge more when vehicles have fewer passengers, and encourage full vehicles by offering lower pricing:
             *
             *       Cars and taxis with no passengers pay an extra Rs50.00
             *       Cars and taxis with two passengers get a Rs10.00 discount.
             *       Cars and taxis with three or more passengers get a Rs25.00 discount.
             *       Buses that are less than 50% full pay an extra Rs250.00.
             *       Buses that are more than 90% full get a Rs500.00 discount.
             * 
             */

            var carPrice1 = CalculateToll(new Car { Passengers = 0});
            var carPrice2 = CalculateToll(new Car { Passengers = 2 });
            var carPrice3 = CalculateToll(new Car { Passengers = 4 });
            var busPrice1 = CalculateToll(new Bus { Capacity = 100, Riders = 35 });
            var busPrice2 = CalculateToll(new Bus { Capacity = 100, Riders = 65 });
            var busPrice3 = CalculateToll(new Bus { Capacity = 100, Riders = 93 });

            Console.WriteLine(carPrice1);
            Console.WriteLine(carPrice2);
            Console.WriteLine(carPrice3);
            Console.WriteLine(busPrice1);
            Console.WriteLine(busPrice2);
            Console.WriteLine(busPrice3);

            // Matching patterns on the basis of object type and property (note the usage of nested switch expression)
            static decimal CalculateToll(object vehicle) => vehicle switch
            {
                Car c => c.Passengers switch
                {
                    0 => 50 + 50,
                    1 => 50,
                    2 => 50 - 10,
                    _ => 50 - 25
                },
                Taxi t => t.Fares switch
                {
                    0 => 100 + 50,
                    1 => 100,
                    2 => 100 - 10,
                    _ => 100 - 25
                },
                Bus b when ((double)b.Riders < (double)b.Capacity / 2) => 1000 + 250,
                Bus b when ((double)b.Riders > (double)b.Capacity * 0.9) => 1000 - 500,
                Bus _ => 1000,
            };
        }
    }
}
