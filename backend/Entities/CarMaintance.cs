namespace CarRentalSystem;
public class CarMaintenance
{
    public int Id { get; set; }

    public int CarId { get; set; }
    public Car Car { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}