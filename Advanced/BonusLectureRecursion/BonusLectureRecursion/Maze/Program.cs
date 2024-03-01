namespace Maze
{
    internal class Program
    {
        static void Main()
        {
            string[] maze = new[]
            {
                "00100",
                "00101",
                "10010",
                "0100E"
            };

            FindPaths(maze, 0, 0, new bool[maze.Length, maze[0].Length], "");
        }
        private static void FindPaths(string[] maze, int row, int col, bool[,] visited, string path)
        {
            if (maze[row][col] == 'E')
            {
                Console.WriteLine(path);
            }
            visited[row, col] = true;

            if (IsValidMove(maze, row + 1, col, visited))
            {
                FindPaths(maze, row + 1, col, visited, path + "D");
            }

            if (IsValidMove(maze, row - 1, col, visited))
            {
                FindPaths(maze, row - 1, col, visited, path + "U");
            }

            if (IsValidMove(maze, row, col + 1, visited))
            {
                FindPaths(maze, row, col + 1, visited, path + "R");
            }

            if (IsValidMove(maze, row, col - 1, visited))
            {
                FindPaths(maze, row, col - 1, visited, path + "L");
            }

            visited[row, col] = false;
        }

        private static bool IsValidMove(string[] maze, int row, int col, bool[,] visited)
        {
            if (row < 0 || col < 0 || row >= maze.Length || col >= maze[0].Length)
            {
                return false;
            }

            if (maze[row][col] == '1' || visited[row, col])
            {
                return false;
            }

            return true;
        }
    }
}
