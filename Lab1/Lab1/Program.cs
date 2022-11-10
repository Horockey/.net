using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
	internal class Program
	{
		static int[] directInsertSort(int[] arr)
		{
			var a = new int[arr.Length];
			arr.CopyTo(a, 0);
			Console.WriteLine("Direct insert sort:");
			for (int i = 2; i < a.Length; i++)
			{
				for(int j = 0; j < i; j++)
				{
					if(a[i] <= a[j])
					{
						var temp = a[i];
						for(int k = i; k > j; k--)
						{
							a[k] = a[k-1];
						}
						a[j] = temp;
					}
				}
				foreach(var el in a)
				{
					Console.Write(el.ToString() + " ");
				}
				Console.WriteLine();
			}
			return a;
		}
		static int[] directSelectSort(int[] arr)
		{
			Console.WriteLine("Direct select sort:");
			var a = new int[arr.Length];
			arr.CopyTo(a, 0);
			for(int i = 0; i < a.Length; i++)
			{
				int minIndex = i;
				for(int j = i+1; j < a.Length; j++)
				{
					if (a[j] < a[minIndex]) minIndex = j;
				}
				int temp = a[i];
				a[i] = a[minIndex];
				a[minIndex] = temp;

				foreach (var el in a) Console.Write(el + " ");
				Console.WriteLine();
			}
			return a;
		}
		static int[] bubbleSort(int[] arr)
		{
			Console.WriteLine("Bubble sort:");
			var a = new int[arr.Length];
			arr.CopyTo(a, 0);
			for(int i = arr.Length; i >= 0; i--)
			{
				for(int j = 1; j < i; j++)
				{
					if(a[j] < a[j - 1])
					{
						int temp = a[j];
						a[j] = a[j - 1];
						a[j - 1] = temp;
					}
				}
				foreach(var el in a) Console.Write(el + " ");
				Console.WriteLine();
			}
			return a;
		}
		static void printElementsPercentage(int[] arr) 
		{
			var dict = new Dictionary<int, int>();
			foreach(var el in arr)
			{
				if (!dict.ContainsKey(el)) dict[el] = 1;
				else dict[el]++;
			}
			foreach(var el in dict)
			{
				Console.WriteLine($"{el.Key}: {100 * el.Value / arr.Length}%");
			}
		}
		static void longestDuplicatingSub(int[] arr)
		{
			int maxStartIndex = 0;
			int maxLength = 0;
			int startIndex = 0;
			int length = 0;
			for(int i = 1; i < arr.Length; i++)
			{
				if (arr[i] == arr[i - 1])
				{
					if (length == 0)
					{
						length = 2;
						startIndex = i - 1;
					}
					else
					{
						length++;
					}
					if (length > maxLength)
					{
						maxLength = length;
						maxStartIndex = startIndex;
					}
				}
				else
				{
					length = 0;
					startIndex = 0;
				}
			}
			if(maxLength > 0)
			{
				Console.WriteLine("Max duplicating sub:");
				for(int i = 0; i < maxLength; i++)
				{
					Console.Write(arr[maxStartIndex + i] + " ");
				}
				Console.WriteLine();
			}
			return;
		}
		static void printMostRearElement(int[] arr)
		{
			var dict = new Dictionary<int, int>();
			foreach(var el in arr)
			{
				if (!dict.ContainsKey(el)) dict[el] = 1;
				else dict[el]++;
			}
			int rearKey = 0;
			int rearVal = 100_000;
			foreach (var el in dict)
			{
				if(el.Value < rearVal)
				{
					rearKey = el.Key;
					rearVal = el.Value;
				}
			}
			Console.WriteLine($"Most rear element: {rearKey} ({rearVal} times)");
		}


		static void matrixParameters(int[,] matrix)
		{
			int[] rowsSum = new int[matrix.GetLength(0)];
			int[] colsSum = new int[matrix.GetLength(1)];
			int mainDiagSum = 0;
			int auxDiagSum = 0;
			for (int i = 0; i < matrix.GetLength(0); i++) rowsSum[i] = 0;
			for (int i = 0; i < matrix.GetLength(1); i++) colsSum[i] = 0;


			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for(int j = 0; j < matrix.GetLength(1); j++)
				{
					rowsSum[i] += matrix[i, j];
					colsSum[j] += matrix[i, j];
					if(matrix.GetLength(0) == matrix.GetLength(1))
					{
						if(i == j)
						{
							mainDiagSum += matrix[i, j];
						}
						if(i == matrix.GetLength(0) - j)
						{
							auxDiagSum += matrix[i, j];
						}
					}
				}
			}

			Console.Write("\nColumns sum: ");
			foreach (var el in colsSum) Console.Write(el + " ");
			Console.Write("\nRows sum: ");
			foreach (var el in rowsSum) Console.Write(el + " ");
			Console.Write("\nMain diag sum: " + mainDiagSum);
			Console.WriteLine("\nAuxillary diag sum: " + auxDiagSum);
		}
		static bool checkFullEnter(int[,] a, int[,] b)
		{
			if (a.GetLength(0) > b.GetLength(0)) return false;
			if (a.GetLength(1) > b.GetLength(1)) return false;
			string[] aStrs = new string[a.GetLength(0)];
			string[] bStrs = new string[b.GetLength(0)];
			for (int i = 0; i < a.GetLength(0); i++)
			{
				string s = "";
				for(int j = 0; j < a.GetLength(1); j++)
				{
					s += a[i, j] + " ";
				}
				aStrs[i] = s;
			}
			for (int i = 0; i < b.GetLength(0); i++)
			{
				string s = "";
				for (int j = 0; j < b.GetLength(1); j++)
				{
					s += b[i, j] + " ";
				}
				bStrs[i] = s;
			}
			for(int bRow = 0; bRow < bStrs.Length; bRow++)
			{
				bool fl = true;
				for(int aRow = 0; aRow < aStrs.Length; aRow++)
				{
					if (!bStrs[bRow + aRow].Contains(aStrs[aRow]))
					{
						fl = false;
						break;
					}
				}
				if (fl) return true;
			}
			return false;
		}
		static bool checkHasCross(int[,] matrix)
		{
			if (matrix.GetLength(0) % 2 == 0 || matrix.GetLength(1) % 2 == 0) return false;
			var value = matrix[matrix.GetLength(0)/2, matrix.GetLength(1)/2];
			bool hasCross = true;
			for(int row = 0; row < matrix.GetLength(0) && hasCross; row++)
			{
				if (matrix[row, matrix.GetLength(1) / 2] != value) hasCross = false;
			}
			for(int col = 0; col < matrix.GetLength(1) && hasCross; col++)
			{
				if (matrix[matrix.GetLength(0) / 2, col] != value) hasCross = false;
			}
			return hasCross;
		}
		static bool checkOnlySortedRows(int[,] matrix, bool ascending = true)
		{
			for(int row = 0; row < matrix.GetLength(0); row++)
			{
				for(int col = 1; col < matrix.GetLength(1); col++)
				{
					if(ascending && matrix[row, col] < matrix[row, col - 1]) return false;
					if(!ascending && matrix[row, col] > matrix[row, col - 1]) return false;
				}
			}
			return true;
		}
		static int[,] sortRowsAndColumns(int[,] matrix)
		{
			int[,] result = new int[matrix.GetLength(0)+1, matrix.GetLength(1)+1];

			for (int row = 0; row < result.GetLength(0)-1; row++)
			{
				for (int col = 0; col < result.GetLength(1)-1; col++)
				{
					result[row, col] = matrix[row, col];
					result[row, result.GetLength(1) - 1] = 0;
					result[result.GetLength(0) - 1, col] = 0;
				}
			}

			for (int row = 0; row < result.GetLength(0)-1; row++)
			{
				for(int col = 0; col < result.GetLength(1)-1; col++)
				{
					result[row, result.GetLength(1)-1] += result[row, col];
					result[result.GetLength(0)-1, col] += result[row, col];
				}
			}

			for(int i = result.GetLength(0)-1; i >= 0; i--)
			{
				for(int row = 1; row < i; row++)
				{
					if(result[row, result.GetLength(1)-1] < result[row-1, result.GetLength(1) - 1])
					{
						var temp = new int[result.GetLength(1)];
						for(int k = 0; k < temp.Length; k++) temp[k] = result[row, k];
						for (int k = 0; k < temp.Length; k++) result[row, k] = result[row - 1, k];
						for (int k = 0; k < temp.Length; k++) result[row-1, k] = temp[k];
					}
				}
			}
			for(int j = result.GetLength(1)-1; j >= 0; j--)
			{
				for(int col = 1; col < j; col++)
				{
					if(result[result.GetLength(0)-1, col] < result[result.GetLength(0) - 1, col-1])
					{
						var temp = new int[result.GetLength(0)];
						for (int k = 0; k < temp.Length; k++) temp[k] = result[k, col];
						for (int k = 0; k < temp.Length; k++) result[k, col] = result[k, col-1];
						for (int k = 0; k < temp.Length; k++) result[k, col-1] = temp[k];
					}
				}
			}

			Console.WriteLine("Sorted matrix:");
			for(int row = 0; row < result.GetLength(0); row++)
			{
				for(int col = 0; col < result.GetLength(1); col++)
				{
					Console.Write(result[row, col] + " ");
				}
				Console.WriteLine();
			}
			return result;
		}

		static void stringArrayParams(List<string> lines)
		{
			var dict = new Dictionary<string, int>();
			int lineIdx = 0;
			foreach(var line in lines)
			{
				var letters = new Dictionary<bool, int>() { { true, 0 }, { false, 0 } };
				var glas = new char[] {'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u' };
				foreach (var word in line.Split(" "))
				{
					if (!dict.ContainsKey(word)) dict[word] = 1;
					else dict[word]++;
					foreach(var ch in word)
					{
						if (glas.Contains(ch)) letters[true]++;
						else if (ch >= 'A' && ch <= 'Z' || ch >= 'a' && ch <= 'z') letters[false]++;
					}
				}
				Console.WriteLine($"For line {lineIdx}: {letters[true]} glas, {letters[false]} sogl");
				lineIdx++;
			}

			string freqWord = "";
			int freqCount = 0;
			foreach(var el in dict)
			{
				if(el.Value > freqCount)
				{
					freqWord = el.Key;
					freqCount = el.Value;
				}
			}
			Console.WriteLine($"Most frequent word: {freqWord}");
		}

		static void Main(string[] args)
		{
			Console.WriteLine("Enter 1-dim array in one line:");
			string s = Console.ReadLine();
			while(s.Contains("  "))
			{
				s = s.Replace("  ", " ");
			}
			var numbers = s.Split(' ');
			int[] arr = new int[numbers.Length];
			try
			{
				for (int i = 0; i < numbers.Length; i++)
				{
					if (numbers[i].Trim() == "") continue;
					arr[i] = int.Parse(numbers[i].Trim());
				}
			}
			catch (FormatException e)
			{
				Console.WriteLine(e.Message);
				return;
			}
			directInsertSort(arr);
			directSelectSort(arr);
			bubbleSort(arr);
			longestDuplicatingSub(arr);
			printElementsPercentage(arr);
			printMostRearElement(arr);

			Console.WriteLine("Enter dimensions of 2-dim matrix in one line:");
			string[] dims;
			try
			{
				s = Console.ReadLine();
				while (s.Contains("  "))
				{
					s = s.Replace("  ", " ");
				}
				dims = s.Split(" ");
			}
			catch (FormatException e){
				Console.WriteLine(e.Message);
				return;
			}
			int w, h;
			try
			{
				h = int.Parse(dims[0].Trim());
				w = int.Parse(dims[1].Trim());
				if (h <= 0 || w <= 0) throw new ArgumentException();
			}
			catch (FormatException e)
			{
				Console.WriteLine(e.Message);
				return;
			}
			catch (ArgumentException e)
			{
				Console.WriteLine(e.Message);
				return;
			}
			int[,] matrix = new int[h,w];
			Console.WriteLine("Enter 2-dim matrix, 1 row per line:");
			for(int i = 0; i < h; i++)
			{
				string[] row;
				try
				{
					s = Console.ReadLine();
					while (s.Contains("  "))
					{
						s = s.Replace("  ", " ");
					}
					row = s.Split(" ");
				}
				catch (FormatException e)
				{
					Console.WriteLine(e.Message);
					return;
				}
				for(int j = 0; j < w; j++)
				{
					try
					{
						matrix[i, j] = int.Parse(row[j].Trim());
					}
					catch (FormatException e)
					{
						Console.WriteLine(e.Message);
						return;
					}
				}
			}
			matrixParameters(matrix);
			Console.WriteLine(checkHasCross(matrix) ? "Matrix HAS cross structure" : "Matrix DOES NOT HAVE cross structure");
			Console.WriteLine(checkOnlySortedRows(matrix) ? "Matrix HAS only sorted rows" : "Matrix DOES NOT HAVE only sorted rows");
			sortRowsAndColumns(matrix);


			Console.WriteLine("Enter 2nd 2-dim matrix dims in one line:");
			string[] dims2;
			int h2, w2;
			try
			{
				dims2 = Console.ReadLine().Split(" ");
				h2 = int.Parse(dims2[0].Trim());
				w2 = int.Parse(dims2[1].Trim());
				if (h <= 0 || w <= 0) throw new ArgumentException();
			}
			catch (FormatException e)
			{
				Console.WriteLine(e.Message);
				return;
			}
			catch(ArgumentException e)
			{
				Console.WriteLine(e.Message);
				return;
			}

			
			int[,] matrix2 = new int[h2, w2];
			for (int i = 0; i < h2; i++)
			{
				string[] row;
				try
				{
					row = Console.ReadLine().Split(" ");
				}
				catch (FormatException e)
				{
					Console.WriteLine(e.Message);
					return;
				}
				for (int j = 0; j < w2; j++)
				{
					matrix2[i, j] = int.Parse(row[j].Trim());
				}
			}

			Console.WriteLine(checkFullEnter(matrix, matrix2) ? "matrix1 IN matrix2" : "matrix1 NOT IN matrix2");

			Console.WriteLine("Enter strings array (empty line is the end of intput):");
			var lines = new List<string>();
			while (true)
			{
				s = Console.ReadLine();
				if (s.Length == 0) break;
				lines.Add(s);
			}
			stringArrayParams(lines);
		}
	}
}