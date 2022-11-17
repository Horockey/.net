using System.Collections;

namespace Lab4
{
	internal class EnumFuncSolutionClass
	{
		private int[] storage;
		public void AddElement(int el)
		{
			storage = storage.Append(el).ToArray();
		}
		public EnumFuncSolutionClass()
		{
			this.storage = new int[0];
		}
		public IEnumerable Range(int from, int to)
		{
			for(int i = from; i < to; i++)
			{
				yield return this.storage[i];
			}
		}
		public int Size{ get {return this.storage.Length; } }
	}
}
