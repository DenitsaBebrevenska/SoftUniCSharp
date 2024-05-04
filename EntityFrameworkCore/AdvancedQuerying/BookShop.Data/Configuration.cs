namespace BookShop.Data;
internal class Configuration
{
    internal static string ConnectionString
        => Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.User);
}
