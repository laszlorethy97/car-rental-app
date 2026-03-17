namespace CarRentalSystem;

public class RentalHistoryGetDTO
{
    public int CarId { get; set; }
    public string LicensePlate {get; set;}
    public string Brand {get; set;}
    public string Model {get; set;}
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string RentStatus { get; set; }
    public int RentPrice {get; set;}
}