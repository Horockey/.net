namespace Lab4
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var en = new EnumerableSolutionClass("isdjb 56 321 sdo 1 032 1 wcmd");
			var dict1 = new Dictionary<string, bool>();
			foreach(var el in en)
			{
				int res;
				if (int.TryParse(el.ToString(), out res)){
					dict1[el.ToString()] = true;
				}
			}
			Console.Write("Result 1: ");
			foreach (var el in dict1)
				Console.Write($"{el.Key} ");

			Console.Write("\n============\n");

			var enf = new EnumFuncSolutionClass("isdjb 56 321 sdo 1 032 1 wcmd");
			var dict2 = new Dictionary<string, bool>();
			foreach(var el in enf.Range(0, enf.Size))
			{
				int res;
				if (int.TryParse(el.ToString(), out res))
				{
					dict2[el.ToString()] = true;
				}
			}
			Console.Write("Result 2: ");
			foreach (var el in dict2)
				Console.Write($"{el.Key} ");
		}
	}
}