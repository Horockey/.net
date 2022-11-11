namespace Lab3
{
	internal interface IElectricSource : IElectricElement
	{
		public IElectricElement[] PluggedDevices { get; }
		public int Plug(IElectricElement device);
		public void Unplug(int idx);
	}
}
