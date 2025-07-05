namespace Full_Stack_Development_Internship_Challenge.Models;

public class CartItem
{
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }

    public decimal ProductTotalPrice => Product.Price * Quantity;
}