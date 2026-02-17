namespace CarRentalSystem;

public class Invoice
{
    public int _id;
    public int _rentId;
    public int? _amount;
    public DateOnly? _issueDate;
    public DateOnly? _payDate;

    public Invoice(int id, int rentId, int? amount, DateOnly? issueDate, DateOnly? payDate)
    {
        _id = id;
        _rentId = rentId;
        _amount = amount;
        _issueDate = issueDate;
        _payDate = payDate;
    }
}