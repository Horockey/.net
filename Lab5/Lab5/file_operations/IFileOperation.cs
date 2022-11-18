namespace Lab5
{
	internal interface IFileOperation
	{
		bool accept(string fileName);
		void process(string fileName);

		string Name { get; }
	}
}
