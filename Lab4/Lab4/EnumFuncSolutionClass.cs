using System.Collections;

namespace Lab4
{
	internal class EnumFuncSolutionClass
	{
		private string[] words;
		public EnumFuncSolutionClass(string s)
		{
			this.words = s.Split(' ');
		}
		public IEnumerable Range(int from, int to)
		{
			for(int i = from; i < to; i++)
			{
				yield return this.words[i];
			}
		}
		public int Size{ get {return this.words.Length; } }
	}
}
