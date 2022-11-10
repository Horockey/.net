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
			computer.Attach(new Monitor(name: "Asus 2410", res: new Monitor.Resolution { width = 1920, height = 1080 }));
			computer.Attach(new Keyboard(name: "Logitech 8471"));
			computer.Attach(new Printer(name: "HP 1100w", printRate: 70));
			computer.Attach(new AudioDevice(name: "Senheiser HS 1", maxLoudness: 42));
			computer.Attach(new ExternalDisk(name: "Seagate 1T", volume: 1024 * 1024));
			
			Console.WriteLine(computer.Describe());
		}
	}
}