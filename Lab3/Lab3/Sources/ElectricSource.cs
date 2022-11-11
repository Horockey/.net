namespace Lab3
{
	internal class PlugEventArgs : EventArgs
	{
		public string Name { get; set; }
		public int Wattage { get; set; }
	}
	internal class ElectricSource : IElectricSource
	{
		private int sockets;
		private int wattage;
		private int wattageLimit;
		private IElectricAppliance[] pluggedDevices;
		public int Wattage {
			get { return wattage; }
			set { if (value >= 0) wattage = value; }
		}
		public int WattageLimit {
			get { return wattageLimit; }
			set { if (value >= 0) wattageLimit = value; }
		}
		public IElectricAppliance[] PluggedDevices {
			get { return pluggedDevices; }
			private set { if (value != null) pluggedDevices = value; }
		}
		public int Sockets
		{
			get { return sockets; }
			private set { if(value > 0) sockets = value; }
		}
		public event MyHandler DevicePlugged;
		public event MyHandler DeviceUnplugged;
		
		public void OnDevicePlug(PlugEventArgs e)
		{
			this.Wattage += e.Wattage;
			if (this.Wattage > this.WattageLimit)
			{
				throw new Exception($"SHORT CIRCUIT! Wattage overdrive in element {this.GetType().Name} recieved from {e.Name}");
			}
		}
		public void OnDeviceUnplug(PlugEventArgs e)
		{
			this.wattage -= e.Wattage;
		}
		public ElectricSource(int wattageLimit, int sockets = 3)
		{
			this.Sockets = sockets;
			this.Wattage = 0;
			this.WattageLimit = wattageLimit;
			this.PluggedDevices = new IElectricAppliance[0];
			this.DevicePlugged += OnDevicePlug; 
			this.DeviceUnplugged += OnDeviceUnplug;
		}
		
		public int Plug(IElectricAppliance device)
		{
			if (device == null) throw new ArgumentNullException(nameof(device));
			if (PluggedDevices.Length >= Sockets) throw new InvalidOperationException("All sockets are plugged");

			PluggedDevices = PluggedDevices.Append(device).ToArray();
			DevicePlugged?.Invoke(new PlugEventArgs() { Name = device.Name, Wattage = device.Wattage});

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
			var device = PluggedDevices[index];
;			PluggedDevices = PluggedDevices.Where((val, idx) => idx != index).ToArray();

			DeviceUnplugged?.Invoke(new PlugEventArgs() { Name = device.Name, Wattage = device.Wattage });
		}
	}
}
