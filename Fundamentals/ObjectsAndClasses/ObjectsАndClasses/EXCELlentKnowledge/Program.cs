using Excel = Microsoft.Office.Interop.Excel;
namespace EXCELlentKnowledge
{
	internal class Program
	{
		static void Main()
		{
			Excel.Application xlApp = new Excel.Application();
			Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"E:\txt\sample_table.xlsx");
			Excel.Worksheet xlWorksheet = xlWorkbook.Worksheets[1];
			Excel.Range xlRange = xlWorksheet.UsedRange;

			int rowCount = xlRange.Rows.Count;
			int colCount = xlRange.Columns.Count;
			bool endReached = false;

			for (int i = 1; i <= rowCount; i++)
			{
				for (int j = 1; j <= colCount; j++)
				{
					if (xlRange.Cells[i, j].Value2 == null)
					{
						endReached = true;
						break;
					}
					string text = xlRange.Cells[i, j].Value2.ToString();
					Console.Write(text + "|");
				}

				if (endReached)
				{
					break;
				}

				Console.WriteLine();
			}

			
			xlWorkbook.Close();
			xlApp.Quit();
		}
	}
}
