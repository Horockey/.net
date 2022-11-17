using System.Collections;

namespace Lab4
{
	internal class EnumerableSolutionClass : IEnumerable
	{
		private string s;
		public EnumerableSolutionClass(string s)
		{
			this.s = s;
		}
		public IEnumerator GetEnumerator() => new Enumerator(s);
	}
	internal class Enumerator : IEnumerator
	{
		public object Current {
			get {
				return words[idx]; 
			} 
		}

		public bool MoveNext() => (++idx < words.Length); 
		public void Reset() { idx = -1; }

		public void Dispose() { }

		private string[] words;
		private int idx;

		public Enumerator(string s)
		{
			this.words = s.Split(' ');
		}
	}
}
