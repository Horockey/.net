namespace Lab3
{
	internal class Kettle : ElectricAppliance
	{
		public Kettle(string name, int wattage = 3_000) : base(name, wattage) { }
	}
	internal class Lathe : ElectricAppliance
	{
		public Lathe(string name, int wattage = 15_000) : base(name, wattage) { }
	}
	internal class Refrigerator : ElectricAppliance
	{
		public Refrigerator(string name, int wattage = 4_500) : base(name, wattage) { }
	}
}
