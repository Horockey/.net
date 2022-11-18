namespace Lab5
{
	internal class OperationOpen : IFileOperation
	{
		public string Name { get; private set; } = "open";

		public bool accept(string fileName)
		{
			// Accepts only .txt files
			return File.Exists(Path.Join(Program.assetsDir, fileName)) && Path.GetExtension(fileName) == ".txt";
		}
		public void process(string fileName)
		{
			fileName = Path.Join(Program.assetsDir, fileName);
			var text = File.ReadAllText(fileName);
			Console.WriteLine(text);
		}
	}
}
