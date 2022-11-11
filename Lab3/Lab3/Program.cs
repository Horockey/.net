namespace Lab3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var bat = new ElectricSource(100);
			bat.Plug(new Kettle("Tefal", 30));
			bat.Plug(new Refrigerator("Moulinex", 70));
			foreach (var el in bat.PluggedDevices){
				Console.WriteLine(el.GetType().Name);
			}
			//bat.Plug(new Lathe("Siemens", 100));
		}
	}
}