using Full_Stack_Development_Internship_Challenge.Models;

namespace Full_Stack_Development_Internship_Challenge.Services;

public class CheckoutService
{
    private  Printer _printer;
    private  ShippingService _shippingService;

    public CheckoutService(Printer printer, ShippingService shippingService)
    {
        _printer = printer;
        _shippingService = shippingService;
    }

    public void Checkout(Customer customer)
    {
        if (!customer.Cart.HasItems())
            Console.WriteLine("Cart is empty.");

        var expiredProducts = customer.Cart.GetExpiredItems();
        if (expiredProducts.Any())
        {
            var message = "Expired products:\n" +
                          string.Join("\n", expiredProducts.Select(e =>
                              $"- {e.Name}, expired on {e.ExpirableBehavior!.ExpiryDate:yyyy-MM-dd}"));
            Console.WriteLine(message);
        }

        var AvailabilityOfRequirdQuantity = customer.Cart.Items.Where(x => x.Quantity > x.Product.Quantity).ToList();
        if (AvailabilityOfRequirdQuantity.Any())
        {
            var message = string.Join(Environment.NewLine,
                AvailabilityOfRequirdQuantity.Select(x =>
                    $"Cannot add {x.Quantity} to cart. Total exceeds stock of {x.Product.Name}: {x.Product.Quantity} available."));

            Console.WriteLine(message);
        }

        var subtotal = customer.Cart.CalculateSubtotal();
        var shipping = customer.Cart.CalculateShippingFee();
        var Amount = subtotal + shipping;

        if (customer.Balance < Amount)
            Console.WriteLine("Insufficient balance.");

        customer.ReduceBalance(Amount);

        foreach ( var item in customer.Cart.Items)   // after Ensuring the Availability Of Requird Quantities in the stock, Reduce Product Quantity after Successful purchase
        {  
            item.Product.Quantity-=item.Quantity;
            if (item.Product.Quantity < 0)
                item.Product.Quantity = 0;
        }
        
        _printer.PrintCheckoutSummary(customer.Cart.Items, subtotal, shipping, Amount);

        var toShip = customer.Cart.GetShippableItems();
        _shippingService.Ship(toShip);

    }
}