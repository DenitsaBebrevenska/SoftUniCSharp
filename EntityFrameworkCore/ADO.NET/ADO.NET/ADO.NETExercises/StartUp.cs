using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace ADO.NETExercises;

public static class StartUp
{
    //there were errors:
    //in the task examples at problem 04
    //task 08 SQL command as given in the SQL file
    //04 order of creation will affect the result of task 07
    //08 will change the results from task 09

    //Problem 02
    private const string GetAllVillainsAndCountOfMinionsSQL =
        @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
            FROM Villains AS v 
            JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
        GROUP BY v.Id, v.Name 
          HAVING COUNT(mv.VillainId) > 3 
        ORDER BY COUNT(mv.VillainId)";

    //Problem 03
    private const string GetVillainNameById = @"SELECT Name FROM Villains WHERE Id = @Id";

    private const string GetVillainMinionsOrdered =
        @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                                     m.Name, 
                                                     m.Age
                                                FROM MinionsVillains AS mv
                                                JOIN Minions As m ON mv.MinionId = m.Id
                                               WHERE mv.VillainId = @Id
                                            ORDER BY m.Name";
    //Problem 04
    private const string GetTownIdByName = @"SELECT Id FROM Towns WHERE Name = @townName";
    private const string GetVillainIdByName = @"SELECT Id FROM Villains WHERE Name = @Name";
    private const string GetMinionIdByName = @"SELECT Id FROM Minions WHERE Name = @Name";
    private const string InsertTown = @"INSERT INTO Towns (Name) VALUES (@townName)";
    private const string InsertVillain = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

    private const string InsertMinion =
        @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

    private const string ConnectVillainToMinion =
        @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";
    //Problem 05
    private const string UpdateTownsToUpper =
        @"UPDATE Towns
             SET Name = UPPER(Name)
           WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

    private const string GetTownsByCountry =
        @" SELECT t.Name 
                 FROM Towns as t
                 JOIN Countries AS c ON c.Id = t.CountryCode
                WHERE c.Name = @countryName";
    //Problem 06
    private const string DeleteMinionsConnectionToVillain =
        @"DELETE FROM MinionsVillains 
                    WHERE VillainId = @villainId";

    private const string DeleteVillain =
        @"DELETE FROM Villains
                    WHERE Id = @villainId";
    //Problem 07
    private const string GetAllMinionNames = @"SELECT Name FROM Minions";
    //Problem 08
    private const string UpdateMinionAgeAndNameById =
            @"UPDATE Minions
                 SET Name = LOWER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
               WHERE Id = @Id";

    private const string SelectNameAndAgeAllMinions = @"SELECT Name, Age FROM Minions";
    //problem 09
    private const string StoredProcedureIncreaseMinionAge = "usp_GetOlder";
    private const string SelectNameAndAgeMinionById = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
    static async Task Main()
    {
        string connectionString =
            Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.User);
        await using SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        //problem 02
        //await PrintVillainsAndMinionCountAsync(connection);

        //problem 03
        //int villainId = int.Parse(Console.ReadLine());
        //await PrintVillainMinionNameAsync(connection, villainId);

        //problem 04
        //string[] minionDetails = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
        //string[] villainDetails = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
        //await AddingMinionsToVillainAsync(connection, minionDetails[1], villainDetails[1]);

        //problem 05
        //string countryName = Console.ReadLine();
        //await ChangeTownNamesCasing(connection, countryName);

        //problem 06
        //int villainId = int.Parse(Console.ReadLine());
        //await DeleteVillainAndRemoveHisMinions(connection, villainId);

        //problem 07
        //await PrintMinionNames(connection);

        //problem 08
        //int[] minionIds = Console.ReadLine()
        //    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        //    .Select(int.Parse)
        //    .ToArray();
        //await ChangeSelectedMinionsAgesAndNamesAndPrintAll(connection, minionIds);

        //problem 09
        //int minionId = int.Parse(Console.ReadLine());
        //await IncreaseAgeThroughStoredProcedure(connection, minionId);
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

    //Problem 05
    static async Task ChangeTownNamesCasing(SqlConnection connection, string countryName)
    {
        SqlCommand getTownsByCountryNameCmd = new SqlCommand(GetTownsByCountry, connection);
        getTownsByCountryNameCmd.Parameters.AddWithValue("@countryName", countryName);
        SqlDataReader reader = await getTownsByCountryNameCmd.ExecuteReaderAsync();

        if (!reader.HasRows)
        {
            Console.WriteLine("No town names were affected.");
            return;
        }

        StringBuilder sb = new StringBuilder();
        int townCount = 0;
        List<string> towns = new List<string>();

        while (await reader.ReadAsync())
        {
            SqlCommand updateTownNameToUpper = new SqlCommand(UpdateTownsToUpper, connection);
            updateTownNameToUpper.Parameters.AddWithValue("@countryName", countryName);
            string currentTown = reader.GetString(reader.GetOrdinal("Name")).ToUpper();
            towns.Add(currentTown);
            townCount++;
        }

        Console.WriteLine($"{townCount} town names were affected."); //could be done through another command with ExecuteNonQuery as well
        Console.WriteLine($"[{string.Join(", ", towns)}]");
    }

    //Problem 06
    static async Task DeleteVillainAndRemoveHisMinions(SqlConnection connection, int villainId)
    {
        await using SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand getVillainNameCmd = new SqlCommand(GetVillainNameById, connection, transaction);
            getVillainNameCmd.Parameters.AddWithValue("@Id", villainId);
            string foundVillainName = (string)await getVillainNameCmd.ExecuteScalarAsync();

            if (foundVillainName is null)
            {
                Console.WriteLine("No such villain was found.");
                return;
            }

            SqlCommand removeVillainMinionRelationsCmd =
                new SqlCommand(DeleteMinionsConnectionToVillain, connection, transaction);

            removeVillainMinionRelationsCmd.Parameters.AddWithValue("@villainId", villainId);
            int releasedMinionCount = await removeVillainMinionRelationsCmd.ExecuteNonQueryAsync();

            SqlCommand deleteVillainCmd = new SqlCommand(DeleteVillain, connection, transaction);
            deleteVillainCmd.Parameters.AddWithValue("@villainId", villainId);
            await deleteVillainCmd.ExecuteNonQueryAsync();

            Console.WriteLine($"{foundVillainName} was deleted.");
            Console.WriteLine($"{releasedMinionCount} minions were released.");

            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
        }
    }

    //Problem 07
    static async Task PrintMinionNames(SqlConnection connection)
    {
        SqlCommand getMinionNamesCmd = new SqlCommand(GetAllMinionNames, connection);
        SqlDataReader reader = await getMinionNamesCmd.ExecuteReaderAsync();
        List<string> minionList = new List<string>();

        while (reader.Read())
        {
            minionList.Add((string)reader["Name"]);
        }

        for (int i = 0; i < minionList.Count / 2; i++)
        {
            Console.WriteLine(minionList[i]);
            Console.WriteLine(minionList[minionList.Count - i - 1]);
        }
    }

    //Problem 08
    static async Task ChangeSelectedMinionsAgesAndNamesAndPrintAll(SqlConnection connection, int[] minionIds)
    {
        //could be done it a transaction but not needed by the task`s instructions

        foreach (int id in minionIds)
        {
            SqlCommand changeAgeAndNameCmd = new SqlCommand(UpdateMinionAgeAndNameById, connection);
            changeAgeAndNameCmd.Parameters.AddWithValue("@Id", id);
            await changeAgeAndNameCmd.ExecuteNonQueryAsync();
        }

        SqlCommand getAllMinionNamesAndAgesCmd = new SqlCommand(SelectNameAndAgeAllMinions, connection);
        SqlDataReader reader = await getAllMinionNamesAndAgesCmd.ExecuteReaderAsync();

        while (reader.Read())
        {
            string minionName = (string)reader["Name"];
            int minionAge = (int)reader["Age"];

            Console.WriteLine($"{minionName} {minionAge}");
        }
    }

    //Problem 09
    static async Task IncreaseAgeThroughStoredProcedure(SqlConnection connection, int minionId)
    {
        SqlCommand increaseAgeThroughProcedureCmd = new SqlCommand(StoredProcedureIncreaseMinionAge, connection);
        increaseAgeThroughProcedureCmd.CommandType = CommandType.StoredProcedure;
        increaseAgeThroughProcedureCmd.Parameters.AddWithValue("@id", minionId);
        await increaseAgeThroughProcedureCmd.ExecuteNonQueryAsync();

        SqlCommand getMinionAgeAndNameByIdCmd = new SqlCommand(SelectNameAndAgeMinionById, connection);
        getMinionAgeAndNameByIdCmd.Parameters.AddWithValue("@Id", minionId);
        SqlDataReader reader = await getMinionAgeAndNameByIdCmd.ExecuteReaderAsync();

        while (reader.Read())
        {
            string minionName = (string)reader["Name"];
            int minionAge = (int)reader["Age"];

            Console.WriteLine($"{minionName} - {minionAge} years old");
        }
    }
}