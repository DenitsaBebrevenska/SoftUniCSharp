
using Microsoft.Data.SqlClient;

public class StartUp
{
    private const string GetAllVillainsAndCountOfMinionsSQL =
        "SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount " +
        "FROM Villains AS v " +
        "JOIN MinionsVillains AS mv ON v.Id = mv.VillainId " +
        "GROUP BY v.Id, v.Name " +
        "HAVING COUNT(mv.VillainId) > 3 " +
        "ORDER BY COUNT(mv.VillainId)";

    private const string GetVillainNameById = "SELECT Name FROM Villains WHERE Id = @Id";

    private const string GetVillainMinionsOrdered =
        @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

    static async Task Main()
    {
        string connectionString =
            Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.User);
        await using SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        //await PrintVillainsAndMinionCountAsync(connection);
        int villainId = int.Parse(Console.ReadLine());
        await PrintVillainMinionNameAsync(connection, villainId);
    }

    // Problem 02
    static async Task PrintVillainsAndMinionCountAsync(SqlConnection connection)
    {
        SqlCommand minionCountPerVillainCmd = new SqlCommand(GetAllVillainsAndCountOfMinionsSQL, connection);
        SqlDataReader reader = await minionCountPerVillainCmd.ExecuteReaderAsync();

        while (reader.Read())
        {
            string villainName = (string)reader["Name"];
            int minionCount = (int)reader["MinionsCount"];
            Console.WriteLine($"{villainName} - {minionCount}");
        }
    }

    // Problem 03

    static async Task PrintVillainMinionNameAsync(SqlConnection connection, int villainId)
    {
        SqlCommand villainNameById = new SqlCommand(GetVillainNameById, connection);
        villainNameById.Parameters.AddWithValue("@Id", villainId);
        string villainName = (string)await villainNameById.ExecuteScalarAsync();

        if (villainName == null)
        {
            Console.WriteLine($"No villain with ID {villainId} exists in the database.");
            return;
        }

        Console.WriteLine($"Villain: {villainName}");

        SqlCommand minionsByVillainCmd = new SqlCommand(GetVillainMinionsOrdered, connection);
        minionsByVillainCmd.Parameters.AddWithValue("@Id", villainId);
        SqlDataReader reader = await minionsByVillainCmd.ExecuteReaderAsync();

        if (!reader.HasRows)
        {
            Console.WriteLine("(no minions)");
            return;
        }

        while (reader.Read())
        {
            long rowNumber = (long)reader["RowNum"];
            string minionName = (string)reader["Name"];
            int age = (int)reader["Age"];

            Console.WriteLine($"{rowNumber}. {minionName} {age}");
        }
    }
}
