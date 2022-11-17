using System.Collections;

namespace Lab4
{
	internal class EnumerableSolutionClass : IEnumerable
	{
		private int[] storage;
		public EnumerableSolutionClass()
		{
			this.storage = new int[0];
		}
		public void AddElement(int el)
		{
			this.storage = this.storage.Append(el).ToArray();
		}
		public IEnumerator GetEnumerator() => new Enumerator(storage);
	}
	internal class Enumerator : IEnumerator
	{
		public object Current {
			get {
				return collection[idx]; 
			} 
		}

		public bool MoveNext() => (++idx < collection.Length); 
		public void Reset() { idx = -1; }

		public void Dispose() { }

		private int[] collection;
		private int idx;

		public Enumerator(int[] collection)
		{
			if (collection == null)
			{
				throw new ArgumentNullException();
			}
			this.collection = collection;
			this.idx = -1;
		}

	}
}
