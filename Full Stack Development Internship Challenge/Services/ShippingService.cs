using Full_Stack_Development_Internship_Challenge.Interfaces;
using Full_Stack_Development_Internship_Challenge.Models;

namespace Full_Stack_Development_Internship_Challenge.Services;

public class ShippingService
{
    public void Ship(List<IShippable> items)
    {
        Console.WriteLine($"\nShipping is in progress....\n");
    }
}