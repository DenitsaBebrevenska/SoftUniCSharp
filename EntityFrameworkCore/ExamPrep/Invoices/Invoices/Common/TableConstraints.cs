namespace Invoices.Common;
public class TableConstraints
{
    //Product
    public const int ProductNameMinLength = 9;
    public const int ProductNameMaxLength = 30;
    public const decimal ProductMinPrice = 5;
    public const decimal ProductMaxPrice = 1000;

    //Address
    public const int AddressStreetNameMinLength = 10;
    public const int AddressStreetNameMaxLength = 20;
    public const int AddressCityMinLength = 5;
    public const int AddressCityMaxLength = 15;
    public const int AddressCountryMinLength = 5;
    public const int AddressCountryMaxLength = 15;

    //Invoice 
    public const int InvoiceMinNumber = 1_000_000_000;
    public const int InvoiceMaxNumber = 1_500_000_000;

    //Client
    public const int ClientNameMinLength = 10;
    public const int ClientNameMaxLength = 25;
    public const int ClientVatMinLength = 10;
    public const int ClientVatMaxLength = 15;
}
