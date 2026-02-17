namespace CarRentalSystem;

public class Invoice
{
    public int Id {get; set;}
    public int RentId {get; set;}
    public int? Amount {get; set;}
    public DateTime? IssueDate {get; set;}
    public DateTime? PayDate {get; set;}
}