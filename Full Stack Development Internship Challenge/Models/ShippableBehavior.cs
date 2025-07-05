using Full_Stack_Development_Internship_Challenge.Interfaces;

namespace Full_Stack_Development_Internship_Challenge.Models;

public class ShippableBehavior : IShippable
{
    public string Name { get; set; }
    public double Weight { get; set; }

    public ShippableBehavior(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    public string GetName()
    {
        return Name;
    }

    public double GetWeight()
    {
        return Weight;
    }

}