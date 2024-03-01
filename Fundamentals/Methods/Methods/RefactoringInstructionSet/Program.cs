using System.Numerics;

namespace RefactoringInstructionSet
{
	class InstructionSetBroken
	{
		static void Main()
		{
			string instruction = Console.ReadLine();

			while (instruction != "END")
			{
				string[] tokens = instruction.Split(' ');

				long result = 0;
				long operandOne = long.Parse(tokens[1]);
				switch (tokens[0])
				{
					case "INC":
					{
						result = operandOne + 1;
						break;
					}
					case "DEC":
					{
						result = operandOne - 1;
						break;
					}
					case "ADD":
					{
						long operandTwo = long.Parse(tokens[2]);
						result = operandOne + operandTwo;
						break;
					}
					case "MLA":
					{
						long operandTwo = long.Parse(tokens[2]);
						result = operandOne * operandTwo;
						break;
					}
				}

				Console.WriteLine(result);
				instruction = Console.ReadLine();
			}
		}
	}
}
