namespace Lab3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var bat = new SolarBattery(100);
			bat.Plug(new Kettle("Tefal", 30));
			bat.Plug(new Kettle("Moulinex", 70));
			foreach (var el in bat.PluggedDevices){
				Console.WriteLine(el);
			}
		}
	}
}