namespace Lab3
{
	internal interface IElectricElement
	{
		abstract public int Wattage { get; set; }
		abstract public int WattageLimit { get; }
	}
}
