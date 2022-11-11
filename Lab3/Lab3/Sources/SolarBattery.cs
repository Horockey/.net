namespace Lab3
{
	internal class SolarBattery : IElectricSource
	{
		private int sockets;
		private int wattage;
		private int wattageLimit;
		private IElectricElement[] pluggedDevices;
		public int Wattage {
			get { return wattage; }
			set { if (value >= 0) wattage = value; }
		}
		public int WattageLimit {
			get { return wattageLimit; }
			set { if (value >= 0) wattageLimit = value; }
		}
		public IElectricElement[] PluggedDevices {
			get { return pluggedDevices; }
			private set { if (value != null) pluggedDevices = value; }
		}
		public int Sockets
		{
			get { return sockets; }
			private set { if(value > 0) sockets = value; }
		}
		public SolarBattery(int wattageLimit, int sockets = 3)
		{
			this.Sockets = sockets;
			this.Wattage = 0;
			this.WattageLimit = wattageLimit;
			this.PluggedDevices = new IElectricElement[0];
		}
		
		public int Plug(IElectricElement device)
		{
			if (device == null) throw new ArgumentNullException(nameof(device));
			if (device is IElectricSource) throw new InvalidOperationException("Can't plug source");
			if (PluggedDevices.Length == Sockets) throw new InvalidOperationException("All sockets are plugged");

			PluggedDevices = PluggedDevices.Append(device).ToArray();
			return PluggedDevices.Length - 1;
		}

		public void Unplug(int index)
		{
			if (index < 0) throw new ArgumentOutOfRangeException($"{nameof(index)} is negative");
			PluggedDevices = PluggedDevices.Where((val, idx) => idx != index).ToArray();
		}
	}
}
