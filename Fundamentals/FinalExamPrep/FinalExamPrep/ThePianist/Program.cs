namespace ThePianist
{
	internal class Program
	{
		static void Main()
		{
			int numberOfPieces = int.Parse(Console.ReadLine());
			Dictionary<string, PieceDetails> piecesMap =
				PopulateInitialMap(numberOfPieces);

			string input;
			while ((input = Console.ReadLine()) != "Stop")
			{
				string[] currentCommand = input.Split('|');
				string action = currentCommand[0];

				if (action == "Add")
				{
					AddPiece(piecesMap,currentCommand);
				}
				else if (action == "Remove")
				{
					RemovePiece(piecesMap, currentCommand);
				}
				else
				{
					ChangeKey(piecesMap, currentCommand);
				}
			}

			foreach (var kvp in piecesMap)
			{
				Console.WriteLine($"{kvp.Key} -> Composer: {kvp.Value.Composer}, Key: {kvp.Value.Key}");
			}
		}

		static Dictionary<string, PieceDetails> PopulateInitialMap(int numberOfPieces)
		{
			Dictionary<string, PieceDetails> piecesMap =
				new Dictionary<string, PieceDetails>();
			for (int i = 0; i < numberOfPieces; i++)
			{
				string[] tokens = Console.ReadLine().Split('|');
				string piece = tokens[0];
				string composer = tokens[1];
				string key = tokens[2];
				piecesMap.Add(piece, new PieceDetails(composer, key));
			}
			return piecesMap;
		}

		static void AddPiece(Dictionary<string, PieceDetails> piecesMap,string[] currentCommand)
		{
			string piece = currentCommand[1];
			if (piecesMap.ContainsKey(piece))
			{
				Console.WriteLine($"{piece} is already in the collection!");
				return;
			}

			string composer = currentCommand[2];
			string key = currentCommand[3];
			piecesMap.Add(piece, new PieceDetails(composer, key));
			Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
		}

		static void RemovePiece(Dictionary<string, PieceDetails> piecesMap,string[] currentCommand)
		{
			string piece = currentCommand[1];
			if (!piecesMap.ContainsKey(piece))
			{
				Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
				return;
			}
			piecesMap.Remove(piece);
			Console.WriteLine($"Successfully removed {piece}!");
		}

		static void ChangeKey(Dictionary<string, PieceDetails> piecesMap,string[] currentCommand)
		{
			string piece = currentCommand[1];
			string newKey = currentCommand[2];
			if (!piecesMap.ContainsKey(piece))
			{
				Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
				return;
			}
					
			PieceDetails currentPiece = piecesMap[piece];
			currentPiece.Key = newKey;
			Console.WriteLine($"Changed the key of {piece} to {newKey}!");
		}
	}
}