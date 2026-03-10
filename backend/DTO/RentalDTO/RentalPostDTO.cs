namespace CarRentalSystem;

public class RentalPostDTO
{
    public int UserId {get; set;}
    public int CarId {get; set;}
    public DateTime StartDate {get; set;}
    public DateTime EndDate {get; set;}
}