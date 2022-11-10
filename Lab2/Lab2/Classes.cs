using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
	abstract class ComputerPart
	{
		protected int price;
		protected string name;

		public int Price { 
			get { return price; } 
			set { if (value >= 0) price = value; }
		}
		public string Name {
			get { return name; }
			set { name = value; }
		}
		public string Description { 
			get { return Describe(); }
		}

		public ComputerPart(string name, int price = 100)
		{
			this.name = name;
			this.price = price;
		}
		public virtual string Describe()
		{
			return $"Name: {name}\nPrice: {price}\n";
		}
	}

	class Monitor : ComputerPart
	{
		public struct Resolution
		{
			public int width;
			public int height;
		}
		protected Resolution res;
		public Resolution Res { get { return res; } }
		public Monitor(string name, Resolution res) : base(name)
		{
			this.res = res;
		}
		public override sealed string Describe()
		{
			return base.Describe() + $"Resolution: {Res.width}x{Res.height}\n";
		}
	}
	class Printer : ComputerPart
	{
		protected int printRate;
		public int PrintRate { get { return printRate; } }
		public Printer(string name, int printRate) : base(name)
		{
			this.printRate = printRate;
		}
		public sealed override string Describe()
		{
			return base.Describe() + $"Printer's print rate is {PrintRate}\n";
		}
	}
	class Keyboard : ComputerPart
	{
		public enum KeyboardType
		{
			Mechanical = 1,
			Membran = 2,
			Mixed = 3
		}
		protected KeyboardType type;
		public KeyboardType Type { get { return type; } }
		public Keyboard(string name, KeyboardType type) : base(name)
		{
			this.type = type;
		}
		public Keyboard(string name) : base(name)
		{
			this.type = KeyboardType.Mechanical;
		}
		public sealed override string Describe()
		{
			return base.Describe() + $"Keyboard type is {Type}\n";
		}
	}
	class ExternalDisk : ComputerPart
	{
		protected long volume;
		public long Volume { get { return volume; } }

		public ExternalDisk(string name, long volume) : base(name)
		{
			this.volume = volume;
		}
		public sealed override string Describe()
		{
			return base.Describe() + $"Disk volume is {Volume}\n";
		}
	}
	class AudioDevice : ComputerPart
	{
		protected int maxLoudness;
		public int MaxLoudness { get { return maxLoudness; } }

		public AudioDevice(string name, int maxLoudness) : base(name)
		{
			this.maxLoudness = maxLoudness;
		}
		public sealed override string Describe()
		{
			return base.Describe() + $"Max loudness is {maxLoudness}\n";
		}
	}

	class Computer : ComputerPart
	{
		public class Memory : ComputerPart
		{
			public int Volume { get; }
			public double Frequency { get; }
			public string Manufacturer { get; }

			private const int DEFAULT_VOLUME = 8 * 1_024;
			private const double DEFAULT_FREQUENCY = 3_192;
			private const string DEFAULT_MANUFACTURER = "Samsung";

			public Memory(string name, int volume = DEFAULT_VOLUME, double frequency = DEFAULT_FREQUENCY, string manufacturer = DEFAULT_MANUFACTURER)
				:base(name)
			{
				this.Volume = volume;
				this.Frequency = frequency;
				this.Manufacturer = manufacturer;
			}
			public sealed override string Describe()
			{
				return base.Describe() + $"Volume: {Volume}\nFrequency: {Frequency}\nManufacturer: {Manufacturer}\n";
			}
		}
		public class Motherboard : ComputerPart
		{
			public string Socket { get; }
			public int PciSlotsCount { get; }

			private const string DEFAULT_SOCKET = "1155";
			private const int DEFAULT_PCI_SLOTS_COUNT = 4;

			public Motherboard(string name, string socket = DEFAULT_SOCKET, int pctSlotsCount = DEFAULT_PCI_SLOTS_COUNT)
				:base(name)
			{
				this.Socket = socket;
				this.PciSlotsCount = pctSlotsCount;
			}
			public sealed override string Describe()
			{
				return base.Describe() + $"Socket: {Socket}\nPci slots: {PciSlotsCount}\n";
			}
			public bool isCompatitable(Processor p)
			{
				return this.Socket == p.Socket;
			}
		}
		public class Processor : ComputerPart
		{
			public int Frequency { get; }
			public string Socket { get; }

			private const int DEFAULT_FREQUENCY = 3096;
			private const string DEFAULT_SOCKET = "1155";

			public Processor (string name, int frequency = DEFAULT_FREQUENCY, string socket = DEFAULT_SOCKET)
				:base(name)
			{
				this.Frequency = frequency;
				this.Socket = socket;
			}
			public sealed override string Describe()
			{
				return base.Describe() + $"Frequency: {Frequency}\nSocket: {Socket}\n";
			}
			public bool isCompatitable(Motherboard mb)
			{
				return this.Socket == mb.Socket;
			}
		}
		public class Disk : ComputerPart
		{
			public double Diameter { get; }
			public double MaxSpeed { get; }

			private const double DEFAULT_DIAMETER = 6.5d;
			private const double DEFAULT_MAX_SPEED = 8 * 1024d;
			public Disk(string name, double diameter = DEFAULT_DIAMETER, double maxSpeed = DEFAULT_MAX_SPEED)
				: base(name)
			{
				this.Diameter = diameter;
			}
			public sealed override string Describe()
			{
				return base.Describe() + $"Diameter: {Diameter}\nMax speed: {MaxSpeed}\n";
			}
		}

		public Memory Ram { get; }
		public Motherboard Mb { get; }
		public Processor Proc { get; }
		public Disk Hdd { get; }
		public List<ComputerPart> Aux { get; }

		public Computer(
			string name,
			Motherboard mb,
			Processor p,
			Memory ram,
			Disk hdd,
			List<ComputerPart> aux = null
		) : base(name)
		{
			this.Price = 0;
			foreach (var arg in new ComputerPart[]{ mb, p, ram, hdd })
			{
				if (arg == null)
				{
					throw new ArgumentNullException(nameof(arg));
				}
				this.Price += arg.Price;
			}
			if (aux != null) {
				foreach (var auxElem in aux)
				{
					this.Price += auxElem.Price;
				}
			}
			
			this.Mb = mb;
			this.Proc = p;
			this.Ram = ram;
			this.Hdd = hdd;
			if(aux != null) this.Aux = aux;
			else this.Aux = new List<ComputerPart>();
		}
		public sealed override string Describe()
		{
			string res = base.Describe() + "\nComputer consists of:\n\n";
			foreach (var arg in new ComputerPart[] { this.Mb, this.Proc, this.Ram, this.Hdd })
			{
				res += $"Type: {arg.GetType().Name}\n{arg.Description}\n";
			}
			res += "\nAlso aux devices attached:\n\n";
			foreach(var aux in Aux)
			{
				res += $"Type: {aux.GetType().Name}\n{aux.Description}\n";
			}
			return res;
		}
		public int Attach(ComputerPart aux)
		{
			if (aux == null) return -1;
			this.Aux.Add(aux);
			this.Price += aux.Price;
			return this.Aux.Count - 1;
		}
		public void Unattach(int idx)
		{
			if (idx < 0) return;
			this.Aux.RemoveAt(idx);
			this.Price -= Aux[idx].Price;
		}
	}
}
