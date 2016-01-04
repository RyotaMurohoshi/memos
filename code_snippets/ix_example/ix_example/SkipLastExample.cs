using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace ix_example
{
	[TestFixture ()]
	public class SkipLastExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L610
		[Test ()]
		public void TestSkipLast ()
		{
			IEnumerable <string> stringEnumerable = new []{ "a", "b", "c", "d", "e" }.SkipLast(3);
			Assert.That (stringEnumerable.Count (), Is.EqualTo (2));
			Assert.That (stringEnumerable.ElementAt (0), Is.EqualTo ("a"));
			Assert.That (stringEnumerable.ElementAt (1), Is.EqualTo ("b"));

			Assert.That (new []{ "a", "b", "c", "d", "e" }.SkipLast(5).Count (), Is.EqualTo (0));
			Assert.That (new []{ "a", "b", "c", "d", "e" }.SkipLast(6).Count (), Is.EqualTo (0));
		}
	}
}
