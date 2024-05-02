namespace MusicHub.Data
{
    public static class Configuration
    {
        public static readonly string ConnectionString =
            Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.User);
    }
}
