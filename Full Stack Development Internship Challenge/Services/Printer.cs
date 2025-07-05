using Full_Stack_Development_Internship_Challenge.Models;

namespace Full_Stack_Development_Internship_Challenge.Services;

public class Printer
{
    public void PrintCheckoutSummary(List<CartItem> items, decimal subtotal, decimal shippingFee, decimal Amount)
    {
        Console.WriteLine("** Shipment notice **");
        foreach (var item in items.Where(i => i.Product.ShippableBehavior != null))
        {
            var name = item.Product.Name;
            var weight = item.Product.ShippableBehavior!.GetWeight();
            Console.WriteLine($"{item.Quantity}x {name} {weight * item.Quantity}g");
        }

        var totalWeight = items
            .Where(i => i.Product.ShippableBehavior != null)
            .Sum(i => i.Product.ShippableBehavior!.GetWeight() * i.Quantity);
        Console.WriteLine($"Total package weight {totalWeight / 1000.0}kg");

        Console.WriteLine("** \n Checkout receipt **");
        foreach (var item in items)
            Console.WriteLine($"{item.Quantity}x {item.Product.Name} {item.ProductTotalPrice}");

        Console.WriteLine("----------------------");
        Console.WriteLine($"Subtotal {subtotal}");
        Console.WriteLine($"Shipping {shippingFee}");
        Console.WriteLine($"Amount {Amount}");
    }
}
