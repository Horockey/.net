namespace Lab3
{
	delegate void MyHandler(PlugEventArgs e);

	internal interface IElectricSource : IElectricElement
	{
		public IElectricAppliance[] PluggedDevices { get; }
		public int Plug(IElectricAppliance device);
		public void Unplug(int idx);
		public event MyHandler DevicePlugged;
		public event MyHandler DeviceUnplugged;
	}
}
