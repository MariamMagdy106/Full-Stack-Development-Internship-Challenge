namespace Full_Stack_Development_Internship_Challenge.Interfaces;

public interface IShippable
{
    public string Name { get; set; }
    public  double Weight { get; set; }
    string GetName();
    double GetWeight();
}