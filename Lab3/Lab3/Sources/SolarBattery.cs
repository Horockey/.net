namespace Lab3.Sources
{
	internal class SolarBattery : ElectricSource
	{
		public SolarBattery(int wattage = 300, int sockets = 3) : base(wattage, sockets) {}
	}
	internal class DieselGenerator : ElectricSource
	{
		public DieselGenerator(int wattage = 5_000, int sockets = 10): base(wattage, sockets) { }
	}
	internal class NuclearPowerStation : ElectricSource
	{
		public NuclearPowerStation(int wattage = 2_000_000_000, int sockets = 1_000) : base(wattage, sockets) { }
	}
}
