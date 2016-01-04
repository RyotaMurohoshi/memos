using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace ix_example
{
	[TestFixture ()]
	public class SelectManyExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Multiple.cs#L54		[Test ()]
		[Test ()]
		public void TestSelectMany ()
		{
			IEnumerable <string> stringEnumerable = new int[]{ 1, 2 }.SelectMany (new []{ "a", "b", "c" });
			Assert.That (stringEnumerable.Count (), Is.EqualTo (6));
			Assert.That (stringEnumerable.ElementAt (0), Is.EqualTo ("a"));
			Assert.That (stringEnumerable.ElementAt (1), Is.EqualTo ("b"));
			Assert.That (stringEnumerable.ElementAt (2), Is.EqualTo ("c"));
			Assert.That (stringEnumerable.ElementAt (3), Is.EqualTo ("a"));
			Assert.That (stringEnumerable.ElementAt (4), Is.EqualTo ("b"));
			Assert.That (stringEnumerable.ElementAt (5), Is.EqualTo ("c"));
		}
	}
}
