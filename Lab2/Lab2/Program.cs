namespace Lab2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var computer = new Computer(
				name: "My best computer",
				mb: new Computer.Motherboard("Asus 1155"),
				p: new Computer.Processor("Intel i3 1102"),
				ram: new Computer.Memory("HyperX 3000"),
				hdd: new Computer.Disk("Seagate 6")
			) ;
			Console.WriteLine(computer.Describe());
		}
	}
}