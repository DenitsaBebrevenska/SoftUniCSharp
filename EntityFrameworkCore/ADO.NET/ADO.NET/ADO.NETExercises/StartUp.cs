using Microsoft.Data.SqlClient;

public class StartUp
{
    private const string GetAllVillainsAndCountOfMinionsSQL =
        @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
            FROM Villains AS v 
            JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
        GROUP BY v.Id, v.Name 
          HAVING COUNT(mv.VillainId) > 3 
        ORDER BY COUNT(mv.VillainId)";


    private const string GetVillainNameById = @"SELECT Name FROM Villains WHERE Id = @Id";

    private const string GetVillainMinionsOrdered =
        @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                                     m.Name, 
                                                     m.Age
                                                FROM MinionsVillains AS mv
                                                JOIN Minions As m ON mv.MinionId = m.Id
                                               WHERE mv.VillainId = @Id
                                            ORDER BY m.Name";

    private const string GetTownIdByName = @"SELECT Id FROM Towns WHERE Name = @townName";
    private const string GetVillainIdByName = @"SELECT Id FROM Villains WHERE Name = @Name";
    private const string GetMinionIdByName = @"SELECT Id FROM Minions WHERE Name = @Name";
    private const string InsertTown = @"INSERT INTO Towns (Name) VALUES (@townName)";
    private const string InsertVillain = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

    private const string InsertMinion =
        @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

    private const string ConnectVillainToMinion =
        @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";

    static async Task Main()
    {
        string connectionString =
            Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.User);
        await using SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        //await PrintVillainsAndMinionCountAsync(connection);
        //int villainId = int.Parse(Console.ReadLine());
        //await PrintVillainMinionNameAsync(connection, villainId);
        string[] minionDetails = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
        string[] villainDetails = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
        await AddingMinionsToVillainAsync(connection, minionDetails[1], villainDetails[1]);
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

    //Problem 04
    static async Task AddingMinionsToVillainAsync(SqlConnection connection, string minionDetails, string villainName)
    {
        string[] minionArgs = minionDetails.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string minionName = minionArgs[0];
        int minionAge = int.Parse(minionArgs[1]);
        string townName = minionArgs[2];

        await using SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand getTownIdByNameCmd = new SqlCommand(GetTownIdByName, connection, transaction);
            getTownIdByNameCmd.Parameters.AddWithValue("@townName", townName);
            object townId = await getTownIdByNameCmd.ExecuteScalarAsync();

            if (townId is null)
            {
                SqlCommand insertTownCmd = new SqlCommand(InsertTown, connection, transaction);
                insertTownCmd.Parameters.AddWithValue("@townName", townName);
                await insertTownCmd.ExecuteNonQueryAsync();
                Console.WriteLine($"Town {townName} was added to the database.");

                townId = await getTownIdByNameCmd.ExecuteScalarAsync();
            }

            SqlCommand getVillainNameById = new SqlCommand(GetVillainIdByName, connection, transaction);
            getVillainNameById.Parameters.AddWithValue("@Name", villainName);
            object villainId = await getVillainNameById.ExecuteScalarAsync();

            if (villainId is null)
            {
                SqlCommand insertVillain = new SqlCommand(InsertVillain, connection, transaction);
                insertVillain.Parameters.AddWithValue("@villainName", villainName);
                await insertVillain.ExecuteNonQueryAsync();
                Console.WriteLine($"Villain {villainName} was added to the database.");
                villainId = await getVillainNameById.ExecuteScalarAsync();
            }


            SqlCommand addMinionCmd = new SqlCommand(InsertMinion, connection, transaction);
            addMinionCmd.Parameters.AddWithValue("@name", minionName);
            addMinionCmd.Parameters.AddWithValue("@age", minionAge);
            addMinionCmd.Parameters.AddWithValue("@townId", townId);
            await addMinionCmd.ExecuteNonQueryAsync();

            SqlCommand getMinionIdCmd = new SqlCommand(GetMinionIdByName, connection, transaction);
            getMinionIdCmd.Parameters.AddWithValue("@Name", minionName);
            int minionId = (int)await getMinionIdCmd.ExecuteScalarAsync();

            SqlCommand assignMinionToVillainCmd = new SqlCommand(ConnectVillainToMinion, connection, transaction);
            assignMinionToVillainCmd.Parameters.AddWithValue("@minionId", minionId);
            assignMinionToVillainCmd.Parameters.AddWithValue("@villainId", villainId);
            await assignMinionToVillainCmd.ExecuteNonQueryAsync();

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");

            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
        }



    }
}
