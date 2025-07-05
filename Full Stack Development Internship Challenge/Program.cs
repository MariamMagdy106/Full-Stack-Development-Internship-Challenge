using Full_Stack_Development_Internship_Challenge.Models;
using Full_Stack_Development_Internship_Challenge.Services;
using Full_Stack_Development_Internship_Challenge.Models;
using Full_Stack_Development_Internship_Challenge.Services;

namespace Fawry_Internship_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var printer = new Printer();
            var shipping = new ShippingService();
            var checkoutService = new CheckoutService(printer, shipping);
         

            var tv = new Product
            {
                Name = "TV",
                Price = 2000,
                Quantity = 2,
                ShippableBehavior = new ShippableBehavior("TV", 3000)
            };

            var cheese = new Product
            {
                Name = "Cheese",
                Price = 100,
                Quantity = 10,
                ExpirableBehavior = new ExpirableBehavior(DateTime.Now.AddDays(-1)),
                ShippableBehavior = new ShippableBehavior("Cheese", 200)
            };

            var biscuits = new Product
            {
                Name = "Biscuits",
                Price = 100,
                Quantity = 5,
                ExpirableBehavior = new ExpirableBehavior(DateTime.Now.AddDays(3)),
                ShippableBehavior = new ShippableBehavior("Biscuits", 350)
            };

            var scratchCard = new Product
            {
                Name = "Scratch Card",
                Price = 100,
                Quantity = 100
            };
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Example 1 : Happy path case ");
            Console.WriteLine("--------------------------------------------------");

            var customer1 = new Customer("Mariam", 3000);
            customer1.Cart.AddItem(tv, 1);
            customer1.Cart.AddItem(biscuits, 1);
            customer1.Cart.AddItem(scratchCard, 3);

            checkoutService.Checkout(customer1);

            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("Example 2 : Expired item case");
            Console.WriteLine("--------------------------------------------------");

            var customer2 = new Customer("Ali", 2000);
            customer2.Cart.AddItem(cheese, 1);
            customer2.Cart.AddItem(biscuits, 1);
            customer2.Cart.AddItem(scratchCard, 3);

            checkoutService.Checkout(customer2);

            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("Example 3 : Not Enough Quantity case");
            Console.WriteLine("--------------------------------------------------");

            var customer3 = new Customer("Omar", 10000);
            customer3.Cart.AddItem(tv, 3);  
            customer3.Cart.AddItem(biscuits, 1);
            customer3.Cart.AddItem(scratchCard, 3);

            checkoutService.Checkout(customer3);
            /* Shipment notice is still being printed because the thrown exception
            message is replaced by a simple printed message to allow the program to continue.
            For testing purposes only. */

            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("Example 4 : Not Enough Customer Balance");
            Console.WriteLine("--------------------------------------------------");
            var customer4 = new Customer("Mohamed", 200);
            customer4.Cart.AddItem(biscuits, 1);
            customer4.Cart.AddItem(scratchCard, 3);

            checkoutService.Checkout(customer4);

        }
      
  

    }
}

