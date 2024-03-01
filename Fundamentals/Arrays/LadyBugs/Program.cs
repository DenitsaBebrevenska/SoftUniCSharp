using System.Runtime.CompilerServices;

namespace LadyBugs
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int fieldSize = int.Parse(Console.ReadLine());
			int[] startingLocations = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
			string move;
			int[] board = PopulateBoard(startingLocations, fieldSize);
			
			while ((move = Console.ReadLine()) != "end")
			{
				string[] moveDetails = move.Split(' ');
				int ladybugIndex = int.Parse(moveDetails[0]);
				int flyLenght = int.Parse(moveDetails[2]);
				string direction = moveDetails[1];
				int currentPosition = ladybugIndex;

				//check instructions, index must be within board, must be occupied and flyLenght must be different than 0
				if (ladybugIndex >= 0 && ladybugIndex <= fieldSize - 1 && board[ladybugIndex] == 1 && flyLenght != 0)
				{
					while (true)
					{
						if (direction == "left")
						{
							if (currentPosition - flyLenght >= 0) // next move will be on board
							{
								if (board[currentPosition - flyLenght] == 0) // moved left and  the spot is vacant
								{
									board[currentPosition] -= 1; //vacate the old spot
									currentPosition -= flyLenght; //calculate new index
									board[currentPosition] += 1; //position on new index
									break; //get new move instructions
								}
								else if (board[currentPosition - flyLenght] != 0) //moved left but spot is taken
								{
									board[currentPosition] -= 1; //vacate old spot
									currentPosition -= flyLenght; //calculate new index
									board[currentPosition] += 1; //stack the bugs
									continue; //keep moving
								}
							}
							else //flies off
							{
								board[currentPosition] -= 1; //remove one bug
								break;
							}
						}
						else if (direction == "right")
						{
							if (currentPosition + flyLenght <= fieldSize - 1 && currentPosition + flyLenght >= 0)
							{
								if (board[currentPosition + flyLenght] == 0) // moved left and  the spot is vacant
								{
									board[currentPosition] -= 1; //vacate the old spot
									currentPosition += flyLenght; //calculate new index
									board[currentPosition] += 1; //position on new index
									break; //get new move instructions
								}
								else if (board[currentPosition + flyLenght] != 0) //moved left but spot is taken
								{
									board[currentPosition] -= 1; //vacate old spot
									currentPosition += flyLenght; //calculate new index
									board[currentPosition] += 1; //stack the bugs
									continue; //keep moving
								}
							}
							else //flies off
							{
								board[currentPosition] -= 1; //remove one bug
								break;
							}
						}
					}
				}
			}
			Console.WriteLine(string.Join(" ", board)); 
		}

		static int[] PopulateBoard(int[] startingLocations, int fieldSize)
		{
			int[] board = new int[fieldSize];
			for (int i = 0; i < startingLocations.Length; i++) //populate the initial board with 1 and 0
			{
				if (startingLocations[i] >= 0 && startingLocations[i] < fieldSize) //some indexes given could be outside of board
				{ board[startingLocations[i]] = 1; }
			}
			return board;
		}
	}
}