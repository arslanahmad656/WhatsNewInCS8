using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNewInCS8Core
{
    // Interfaces are greatly enhanced in C# 8.0
    // Default implementation for interface members are available in only in .NET Standard 2.1 and later versions.
    // Now interfaces can also include members including fields and methods. Different access modifiers are also available.
    interface IProduct
    {
        private static decimal _discountedPrice;

        public int ProductCode { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        // A method with a default implementation.
        public decimal GetDiscountedPrice()
        {
            return _discountedPrice;
        }

        public static void SetDiscountedPrice(decimal value)
        {
            _discountedPrice = value;
        }
    }

    class SampleProduct : IProduct
    {
        private int _productCode;
        private decimal _price;
        private string _name;

        public int ProductCode { get => _productCode; set => _productCode = value; }
        public decimal Price { get => _price; set => _price = value; }
        public string Name { get => _name; set => _name = value; }
    }

    class AnotherProduct : IProduct
    {
        private int _productCode;
        private decimal _price;
        private string _name;

        public int ProductCode { get => _productCode; set => _productCode = value; }
        public decimal Price { get => _price; set => _price = value; }
        public string Name { get => _name; set => _name = value; }

        // overriding the default implementation
        public decimal GetDiscountedPrice()
        {
            return Price * 0.9M;
        }
    }

    class DefaultInterfaceImplementation
    {
        public static void Run()
        {
            DemoDefaultImplementation();
            Console.WriteLine($"Read the code for {typeof(DefaultInterfaceImplementation)} along with comments for details.");
        }

        static void DemoDefaultImplementation()
        {
            // initially everything might be fine with the first release of the interface IProduct:
            SampleProduct product = new SampleProduct
            {
                Name = "Media Control Enabled Keyboard",
                Price = 1125.50M,
                ProductCode = 45873
            };

            // Later it is required that a method for calculating discounted price should be added to the interface IProduct. But then this would
            // be a breaking change since the method would have to be implemented by all existing clients of the interface. With the introduction of 
            // default implementations in interfaces, this can be done in a non-breaking way by providing a default implementation of the method for
            // calculating a discounted price. The interfaces also provide a way to control the default behavior for existing clients of the interface.

            AnotherProduct product2 = new AnotherProduct
            {
                Name = "Gaming Mouse",
                Price = 1899.95M,
                ProductCode = 7758
            };
            var discountedPrice = product2.GetDiscountedPrice();
            Console.WriteLine($"{discountedPrice:C}");

            // The clients having older implementations (which don't override the default implementation) cannot access the default implementation using
            // the reference to the concrete type. This is because the default implementation lies in the interface and in order to preserve the pattern,
            // is only available by using a reference to interface type.
            IProduct productAsIProduct = product;
            var discountedPrinceDefault = productAsIProduct.GetDiscountedPrice();
            Console.WriteLine($"{discountedPrinceDefault:C}");
            IProduct.SetDiscountedPrice(99M);
            var discountedPrice2 = productAsIProduct.GetDiscountedPrice();
            Console.WriteLine($"{discountedPrice2:C}");
        }
    }
}
