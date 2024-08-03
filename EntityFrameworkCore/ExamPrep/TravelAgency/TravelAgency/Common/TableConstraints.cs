namespace TravelAgency.Common;
public class TableConstraints
{
    //Customer
    public const int CustomerNameMinLength = 4;
    public const int CustomerNameMaxLength = 60;
    public const int CustomerEmailMinLength = 6;
    public const int CustomerEmailMaxLength = 50;
    public const int CustomerPhoneNumberLength = 13;
    public const string CustomerPhoneNumberPattern = @"\+\d{12}";

    //Guide
    public const int GuideNameMinLength = 4;
    public const int GuideNameMaxLength = 60;

    //TourPackage
    public const int PackageNameMinLength = 2;
    public const int PackageNameMaxLength = 40;
    public const int PackageDescriptionMaxLength = 200;
    public const decimal PackagePriceMinValue = 0;
}
