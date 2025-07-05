using Full_Stack_Development_Internship_Challenge.Interfaces;
using Full_Stack_Development_Internship_Challenge.Services;

namespace Full_Stack_Development_Internship_Challenge.Models;

public class Cart
{
    public List<CartItem> Items { get; set; } = new();
    public void AddItem(Product product, int quantity)
    {
        var existing = Items.FirstOrDefault(i => i.Product == product);

        if (existing != null)
            existing.Quantity += quantity;
        else
            Items.Add(new CartItem { Product = product, Quantity = quantity });
    }


    public List<Product> GetExpiredItems()
    {
        return Items
            .Where(i => i.Product.ExpirableBehavior?.IsExpired() == true)
            .Select(i => i.Product)
            .ToList();
    }

    public List<IShippable> GetShippableItems()
    {
        return Items
            .Where(i => i.Product.ShippableBehavior != null)
            .Select(i => i.Product.ShippableBehavior!)
            .ToList();
    }

    public decimal CalculateSubtotal() =>
        Items.Sum(i => i.ProductTotalPrice);

    public decimal CalculateShippingFee() =>
        Items.Where(i => i.Product.ShippableBehavior != null)
            .Sum(i => (decimal)5); // assuming for each item 5$ shipping fees

    public double GetTotalWeight() =>
        Items.Where(i => i.Product.ShippableBehavior != null)
            .Sum(i => i.Product.ShippableBehavior!.GetWeight() * i.Quantity);

    public bool HasItems() => Items.Any();
}