namespace Trucks.Common;
public class TableConstraints
{
    //Truck
    public const int TruckRegistrationNumberLength = 8;
    public const int TruckVinLength = 17;
    public const int TruckTankMinCapacity = 950;
    public const int TruckTankMaxCapacity = 1420;
    public const int TruckCargoMinCapacity = 5000;
    public const int TruckCargoMaxCapacity = 29_000;

    //Client
    public const int ClientNameMinLength = 3;
    public const int ClientNameMaxLength = 40;
    public const int ClientNationalityMinLength = 2;
    public const int ClientNationalityMaxLength = 40;

    //Despatcher
    public const int DespatcherNameMinLength = 2;
    public const int DespatcherNameMaxLength = 40;
}
