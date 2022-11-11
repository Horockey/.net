namespace Lab3
{
	internal class ElectricAppliance : IElectricAppliance
	{
		private string name;
		private int wattage;
		private int wattageLimit;

		public string Name { get { return name; } private set { name = value; } }
		public int WattageLimit { get { return wattageLimit; } private set { if (value >= 0) wattageLimit = value; } }
		public int Wattage { get { return wattage; } set { if (value >= 0 && value <= wattageLimit) wattage = value; } }
		public ElectricAppliance(string name, int wattage)
		{
			this.Name = name;
			this.WattageLimit = wattage;
			this.Wattage = wattage;
		}
	}
}
