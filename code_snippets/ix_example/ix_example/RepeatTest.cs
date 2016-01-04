using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace ix_example
{

	[TestFixture ()]
	public class RepeatTest
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Creation.cs#L172
		[Test ()]
		public void TestRepeat_T()
		{
			IEnumerable <int> enumerable = EnumerableEx.Repeat (0);
			Assert.That (enumerable.ElementAt (0), Is.EqualTo (0));
			Assert.That (enumerable.ElementAt (1), Is.EqualTo (0));
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Creation.cs#L185
		[Test ()]
		public void TestRepeat_T_Int ()
		{
			IEnumerable <int> enumerable = EnumerableEx.Repeat(1, 3);
			Assert.That (enumerable.ElementAt (0), Is.EqualTo (1));
			Assert.That (enumerable.ElementAt (1), Is.EqualTo (1));
			Assert.That (enumerable.ElementAt (2), Is.EqualTo (1));
			Assert.That (enumerable.Count (), Is.EqualTo (3));
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L638
		[Test ()]
		public void TestRepeat_EnumerableT ()
		{
			IEnumerable <int> enumerable = new []{0, 1, 2}.Repeat();
			Assert.That (enumerable.ElementAt (0), Is.EqualTo (0));
			Assert.That (enumerable.ElementAt (1), Is.EqualTo (1));
			Assert.That (enumerable.ElementAt (2), Is.EqualTo (2));
			Assert.That (enumerable.ElementAt (3), Is.EqualTo (0));
			Assert.That (enumerable.ElementAt (4), Is.EqualTo (1));
			Assert.That (enumerable.ElementAt (5), Is.EqualTo (2));
			Assert.That (enumerable.ElementAt (6), Is.EqualTo (0));
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L660
		[Test ()]
		public void TestRepeat_EnumerableT_Int ()
		{
			IEnumerable <int> enumerable = new []{0, 1, 2}.Repeat(count: 3);
			Assert.That (enumerable.ElementAt (0), Is.EqualTo (0));
			Assert.That (enumerable.ElementAt (1), Is.EqualTo (1));
			Assert.That (enumerable.ElementAt (2), Is.EqualTo (2));
			Assert.That (enumerable.ElementAt (3), Is.EqualTo (0));
			Assert.That (enumerable.ElementAt (4), Is.EqualTo (1));
			Assert.That (enumerable.ElementAt (5), Is.EqualTo (2));
			Assert.That (enumerable.ElementAt (6), Is.EqualTo (0));
			Assert.That (enumerable.ElementAt (7), Is.EqualTo (1));
			Assert.That (enumerable.ElementAt (8), Is.EqualTo (2));
			Assert.That (enumerable.Count (), Is.EqualTo (9));
		}
	}
}

