namespace Lab5
{
	internal class OperationGetStat : IFileOperation
	{
		public string Name { get; private set; } = "get_stat";
		public bool accept(string fileName)
		{
			return File.Exists(Path.Join(Program.assetsDir,  fileName));
		}
		public void process(string fileName)
		{
			fileName = Path.Join(Program.assetsDir, fileName);
			FileInfo info = new FileInfo(fileName);
			
			Console.WriteLine(
				$"Name: {info.Name}\n" +
				$"Size: {info.Length} bytes\n" +
				$"Last modified: {info.LastWriteTimeUtc}\n"
			);
		}
	}
}
