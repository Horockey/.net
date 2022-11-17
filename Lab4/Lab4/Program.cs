namespace Lab4
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var en = new EnumerableSolutionClass();
			en.AddElement(1);
			en.AddElement(2);
			en.AddElement(3);
			foreach(var el in en)
			{
				Console.WriteLine(el);
			}

			Console.Write("\n============\n");

			var enf = new EnumFuncSolutionClass();
			enf.AddElement(1);
			enf.AddElement(2);
			enf.AddElement(3);
			foreach(var el in enf.Range(0, enf.Size))
			{
				Console.WriteLine(el);
			}
		}
	}
}