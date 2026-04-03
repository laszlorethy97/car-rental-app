namespace CarRentalSystem;

public class CarPostDTO
{
    public string? LicensePlate { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public int? Year { get; set; }
    public int? Kilometrage { get; set; }
    public int? RentPrice { get; set; }
    public string CarStatus { get; set; }
}