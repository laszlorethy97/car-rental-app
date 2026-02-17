namespace CarRentalSystem;

public class Car
{
    public int _id;
    public string? _licensePlate;
    public string? _brand;
    public string? _model;
    public int? _year;
    public int? _kilometrage;
    public int? _rentPrice;
    public CarStatus _carStatus;

    public Car(int id, string? licensePlate, string? brand, string? model, int? year, int? kilometrage, int? rentPrice, CarStatus carStatus)
    {
        _id = id;
        _licensePlate = licensePlate;
        _brand = brand;
        _model = model;
        _year = year;
        _kilometrage = kilometrage;
        _rentPrice = rentPrice;
        _carStatus = carStatus;
    }
}