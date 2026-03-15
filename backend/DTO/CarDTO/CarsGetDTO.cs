namespace CarRentalSystem;

public class CarsGetDTO
{
    public int Id {get; set;}
    public string LicensePlate {get; set;}
    public string Brand {get; set;}
    public string Model {get; set;}
    public int Year {get; set;}
    public int Kilometrage {get; set;}
    public int RentPrice {get; set;}
    public CarStatus CarStatus {get; set;}
}