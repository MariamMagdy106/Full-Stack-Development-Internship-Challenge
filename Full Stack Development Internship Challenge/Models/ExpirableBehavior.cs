using Full_Stack_Development_Internship_Challenge.Interfaces;

namespace Full_Stack_Development_Internship_Challenge.Models;

public class ExpirableBehavior : IExpirable
{
    public DateTime ExpiryDate { get; set; }
   
    public bool IsExpired() => DateTime.Now > ExpiryDate;

    public ExpirableBehavior(DateTime expiryDate)
    {
        ExpiryDate = expiryDate;
    }

}