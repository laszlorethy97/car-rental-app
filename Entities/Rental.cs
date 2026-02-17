namespace CarRentalSystem;

public class Rental
{
    public int _id;
    public int _userId;
    public int _carId;
    public DateOnly? _startDate;
    public DateOnly? _endDate;
    public RentStatus? _rentStatus;
    public bool _approved;

    public Rental(int id, int userId, int carId, DateOnly? startDate, DateOnly? endDate, RentStatus? rentStatus, bool approved)
    {
        _id = id;
        _userId = userId;
        _carId = carId;
        _startDate = startDate;
        _endDate = endDate;
        _rentStatus = rentStatus;
        _approved = approved;
    }
}