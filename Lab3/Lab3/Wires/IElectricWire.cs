namespace Lab3
{
	internal interface IElectricWire : IElectricElement
	{
		abstract public IElectricElement[] Inputs { get; set; }
		abstract public IElectricElement[] Outputs { get; set; }
	}
}
