namespace CarRentalSystem;

public class RentalHistoryGetDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CarId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public RentStatus RentStatus { get; set; }
    public int ApprovedByUserId { get; set; }

}