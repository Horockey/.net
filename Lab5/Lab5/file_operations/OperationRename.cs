using System.IO;

namespace Lab5
{
	internal class OperationRename : IFileOperation
	{
		public string Name { get; private set; } = "rename";
		public bool accept(string fileName)
		{
			// Accepts all files
			return File.Exists(Path.Join(Program.assetsDir, fileName));
		}
		public void process(string fileName)
		{
			fileName = Path.Join(Program.assetsDir, fileName);
			Console.WriteLine("Enter new file name:");
			var newFileName = Console.ReadLine();
			if (newFileName == null)
				throw new ArgumentNullException();
			System.IO.File.Move(
				fileName,
				System.IO.Path.Join(Program.assetsDir, newFileName));
		}
	}
}
