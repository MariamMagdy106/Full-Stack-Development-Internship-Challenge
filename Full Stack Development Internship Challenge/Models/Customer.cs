using Full_Stack_Development_Internship_Challenge.Services;

namespace Full_Stack_Development_Internship_Challenge.Models;

public class Customer
{
    public string Name { get; set; }
    public decimal Balance { get;  set; }
    public Cart Cart { get; set; } = new Cart();

    public Customer(string name, decimal balance)
    {
        Name = name;
        Balance = balance;
        
    }

    public void ReduceBalance(decimal amount)
    {
        Balance -= amount;
    }
}