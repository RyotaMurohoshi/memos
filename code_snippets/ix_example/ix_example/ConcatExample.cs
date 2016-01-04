using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace ix_example
{
	[TestFixture ()]
	public class ConcatExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Multiple.cs#L17
		[Test ()]
		public void Concat_IEnumerableIEnumerableT ()
		{
			{
				IEnumerable <int> intEnumerable = new int[][]{ new int[]{ 3, 1, 4 }, new int[]{ 1 }, new int[]{ 5, 9, 2 } }.Concat ();
				Assert.That (intEnumerable.ElementAt (0), Is.EqualTo (3));
				Assert.That (intEnumerable.ElementAt (1), Is.EqualTo (1));
				Assert.That (intEnumerable.ElementAt (2), Is.EqualTo (4));
				Assert.That (intEnumerable.ElementAt (3), Is.EqualTo (1));
				Assert.That (intEnumerable.ElementAt (4), Is.EqualTo (5));
				Assert.That (intEnumerable.ElementAt (5), Is.EqualTo (9));
				Assert.That (intEnumerable.ElementAt (6), Is.EqualTo (2));
			}

			{
				IEnumerable <int> intEnumerable = new List<List<int>> { new List<int>{ 3, 1, 4 }, new List<int>{ 1 }, new List<int> { 5, 9, 2 }}.Concat ();
				Assert.That (intEnumerable.ElementAt (0), Is.EqualTo (3));
				Assert.That (intEnumerable.ElementAt (1), Is.EqualTo (1));
				Assert.That (intEnumerable.ElementAt (2), Is.EqualTo (4));
				Assert.That (intEnumerable.ElementAt (3), Is.EqualTo (1));
				Assert.That (intEnumerable.ElementAt (4), Is.EqualTo (5));
				Assert.That (intEnumerable.ElementAt (5), Is.EqualTo (9));
				Assert.That (intEnumerable.ElementAt (6), Is.EqualTo (2));
			}

			{
				IEnumerable <int> intEnumerable = new List<IEnumerable<int>> { new int[]{ 3, 1, 4 }, new List<int>{ 1 },new int[] { 5, 9, 2 }}.Concat ();
				Assert.That (intEnumerable.ElementAt (0), Is.EqualTo (3));
				Assert.That (intEnumerable.ElementAt (1), Is.EqualTo (1));
				Assert.That (intEnumerable.ElementAt (2), Is.EqualTo (4));
				Assert.That (intEnumerable.ElementAt (3), Is.EqualTo (1));
				Assert.That (intEnumerable.ElementAt (4), Is.EqualTo (5));
				Assert.That (intEnumerable.ElementAt (5), Is.EqualTo (9));
				Assert.That (intEnumerable.ElementAt (6), Is.EqualTo (2));
			}
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Multiple.cs#L31
		[Test ()]
		public void Concat_ParamsIEnumerableT ()
		{
			{
				IEnumerable <int> intEnumerable = EnumerableEx.Concat<int> (new int[]{ 3, 1, 4, 1, 5, 9, 2 });
				Assert.That (intEnumerable.ElementAt (0), Is.EqualTo (3));
				Assert.That (intEnumerable.ElementAt (1), Is.EqualTo (1));
				Assert.That (intEnumerable.ElementAt (2), Is.EqualTo (4));
				Assert.That (intEnumerable.ElementAt (3), Is.EqualTo (1));
				Assert.That (intEnumerable.ElementAt (4), Is.EqualTo (5));
				Assert.That (intEnumerable.ElementAt (5), Is.EqualTo (9));
				Assert.That (intEnumerable.ElementAt (6), Is.EqualTo (2));
			}

			{
				IEnumerable <int> intEnumerable = EnumerableEx.Concat<int> (new List<int>{ 3, 1, 4, 1, 5, 9, 2 });
				Assert.That (intEnumerable.ElementAt (0), Is.EqualTo (3));
				Assert.That (intEnumerable.ElementAt (1), Is.EqualTo (1));
				Assert.That (intEnumerable.ElementAt (2), Is.EqualTo (4));
				Assert.That (intEnumerable.ElementAt (3), Is.EqualTo (1));
				Assert.That (intEnumerable.ElementAt (4), Is.EqualTo (5));
				Assert.That (intEnumerable.ElementAt (5), Is.EqualTo (9));
				Assert.That (intEnumerable.ElementAt (6), Is.EqualTo (2));
			}

			{
				IEnumerable <int> intEnumerable = EnumerableEx.Concat (new int[]{ 3, 1, 4 }, new int[]{ 1 }, new int[]{ 5, 9, 2 });
				Assert.That (intEnumerable.ElementAt (0), Is.EqualTo (3));
				Assert.That (intEnumerable.ElementAt (1), Is.EqualTo (1));
				Assert.That (intEnumerable.ElementAt (2), Is.EqualTo (4));
				Assert.That (intEnumerable.ElementAt (3), Is.EqualTo (1));
				Assert.That (intEnumerable.ElementAt (4), Is.EqualTo (5));
				Assert.That (intEnumerable.ElementAt (5), Is.EqualTo (9));
				Assert.That (intEnumerable.ElementAt (6), Is.EqualTo (2));
			}

			{
				IEnumerable <int> intEnumerable = EnumerableEx.Concat (new List<int>{ 3, 1, 4 }, new List<int>{ 1 }, new List<int>{ 5, 9, 2 });
				Assert.That (intEnumerable.ElementAt (0), Is.EqualTo (3));
				Assert.That (intEnumerable.ElementAt (1), Is.EqualTo (1));
				Assert.That (intEnumerable.ElementAt (2), Is.EqualTo (4));
				Assert.That (intEnumerable.ElementAt (3), Is.EqualTo (1));
				Assert.That (intEnumerable.ElementAt (4), Is.EqualTo (5));
				Assert.That (intEnumerable.ElementAt (5), Is.EqualTo (9));
				Assert.That (intEnumerable.ElementAt (6), Is.EqualTo (2));
			}
		}
	}
}
