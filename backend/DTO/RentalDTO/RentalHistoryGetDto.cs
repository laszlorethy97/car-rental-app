namespace CarRentalSystem;

public class RentalHistoryGetDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CarId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public RentStatus? RentStatus { get; set; }
    public int? ApprovedByUserId { get; set; }

    //Car details
    public string? LicensePlate {get; set;}
    public string? Brand {get; set;}
    public string? Model {get; set;}
    public int? Year {get; set;}
    public int? Kilometrage {get; set;}
    public int? RentPrice {get; set;}
    public CarStatus CarStatus {get; set;}

    //user details
    public string? Email {get; set;}
    public string? UserName {get; set;}
    public string? PhoneNumber {get; set;}
}