namespace Full_Stack_Development_Internship_Challenge.Interfaces;

public interface IExpirable
{
    public DateTime ExpiryDate { get; set; }
    bool IsExpired();
}