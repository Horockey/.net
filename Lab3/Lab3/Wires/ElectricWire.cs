namespace Lab3
{
	internal class ElectricWire : IElectricWire
	{
		private string name;
		private IElectricSource input;
		private IElectricAppliance[] outputs;
		private int wattage;
		private int wattageLimit;
		private int sockets;

		public void OnDevicePlug(PlugEventArgs e)
		{
			this.Wattage += e.Wattage;
			if (this.Wattage > this.WattageLimit)
			{
				throw new Exception($"SHORT CIRCUIT! Wattage overdrive in element {this.Name} recieved from {e.Name}");
			}
		}
		public void OnDeviceUnplug(PlugEventArgs e)
		{
			this.wattage -= e.Wattage;
		}

		public string Name { get { return name; } set { name = value; } }
		public IElectricSource Input { get { return input; } private set { if (value != null) input = value; } }
		public IElectricAppliance[] PluggedDevices {
			get { return outputs; }
			private set { if (value != null) outputs = value; }
		}
		public int Wattage{ get { return wattage; } set { if (value >= 0 && value <= WattageLimit) ; } }
		public int WattageLimit { get { return wattageLimit; } private set { if (value >= 0) wattageLimit = value; } }
		public int Sockets { get { return sockets; } private set { if (value >= 0) sockets = value; } }

		public event MyHandler DevicePlugged;
		public event MyHandler DeviceUnplugged;
		public ElectricWire(IElectricSource source, int wattageLimit)
		{
			this.WattageLimit = wattageLimit;
			this.Wattage = 0;
			this.Input = source;
			this.PluggedDevices = new IElectricAppliance[0];
		}
		public int Plug(IElectricAppliance device)
		{
			if (device == null) throw new ArgumentNullException(nameof(device));
			if (PluggedDevices.Length >= Sockets) throw new InvalidOperationException("All sockets are plugged");

			PluggedDevices = PluggedDevices.Append(device).ToArray();
			if(device is IElectricSource)
			{
				((ElectricSource)device).DevicePlugged += OnDevicePlug;
				((ElectricSource)device).DeviceUnplugged += OnDeviceUnplug;
			}

			return PluggedDevices.Length - 1;
		}
		public void Unplug(int index)
		{
			if (index < 0) throw new ArgumentOutOfRangeException($"{nameof(index)} is negative");
			PluggedDevices = PluggedDevices.Where((val, idx) => idx != index).ToArray();
		}
	}
}
