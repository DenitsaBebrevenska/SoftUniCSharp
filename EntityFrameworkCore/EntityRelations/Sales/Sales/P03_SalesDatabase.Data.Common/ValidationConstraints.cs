namespace P03_SalesDatabase.Data.Common;
public static class ValidationConstraints
{
    //Product
    public const int ProductNameLength = 50;

    //Customer
    public const int CustomerNameLength = 100;
    public const int CustomerEmailLength = 80;
    public const int CustomerCreditCardLength = 20;

    //Store
    public const int StoreNameLength = 80;
}
