using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace ix_example
{
	[TestFixture ()]
	public class TakeLastExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L573
		[Test ()]
		public void TestTakeLast ()
		{
			IEnumerable <string> stringEnumerable = new []{ "a", "b", "c", "d", "e" }.TakeLast(3);
			Assert.That (stringEnumerable.Count (), Is.EqualTo (3));
			Assert.That (stringEnumerable.ElementAt (0), Is.EqualTo ("c"));
			Assert.That (stringEnumerable.ElementAt (1), Is.EqualTo ("d"));
			Assert.That (stringEnumerable.ElementAt (2), Is.EqualTo ("e"));

			Assert.That (new []{ "a", "b", "c", "d", "e" }.TakeLast(5).Count (), Is.EqualTo (5));
			Assert.That (new []{ "a", "b", "c", "d", "e" }.TakeLast(6).Count (), Is.EqualTo (5));
		}
	}
}
