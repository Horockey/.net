namespace Lab5
{
	internal class Program
	{
		public static string assetsDir = "D:\\Repos\\.net\\Lab5\\Lab5\\assets\\";
		static void Main(string[] args)
		{
			var operations = new IFileOperation[] {
				new OperationOpen(),
				new OperationGetStat(),
				new OperationRename(),
			};
			var operDict = new Dictionary<string, IFileOperation>();
			Console.WriteLine("Avaliable commands:");
			foreach (var operation in operations)
			{
				operDict[operation.Name] = operation;
				Console.WriteLine(operation.Name);
			}
			Console.WriteLine("Enter operation name:");
			var selectedOperationName = Console.ReadLine();
			var selectedOperation = operDict[selectedOperationName];
			Console.WriteLine("Enter file name:");
			var fileName = Console.ReadLine();
			if (!selectedOperation.accept(fileName))
			{
				Console.WriteLine("Operation has declined file");
				return;
			}
			selectedOperation.process(fileName);
		}
	}
}