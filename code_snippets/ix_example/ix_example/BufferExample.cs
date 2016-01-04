﻿using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace ix_example
{
	[TestFixture ()]
	public class BufferExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L201
		[Test ()]
		public void TestBufferInt ()
		{
			IEnumerable <IList<string>> enumerable = new []{ "a", "b", "c", "d", "e" }.Buffer (2);
			Assert.That (enumerable.Count (), Is.EqualTo (3));
			Assert.True (enumerable.ElementAt (0).SequenceEqual (new []{ "a", "b" }));
			Assert.True (enumerable.ElementAt (1).SequenceEqual (new []{ "c", "d" }));
			Assert.True (enumerable.ElementAt (2).SequenceEqual (new []{ "e" }));
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L219
		[Test ()]
		public void TestBufferIntInt ()
		{
			{
				IEnumerable <IList<string>> enumerable = new []{ "a", "b", "c", "d", "e" }.Buffer (2, 1);
				Assert.That (enumerable.Count (), Is.EqualTo (5));
				Assert.True (enumerable.ElementAt (0).SequenceEqual (new []{ "a", "b" }));
				Assert.True (enumerable.ElementAt (1).SequenceEqual (new []{ "b", "c" }));
				Assert.True (enumerable.ElementAt (2).SequenceEqual (new []{ "c", "d" }));
				Assert.True (enumerable.ElementAt (3).SequenceEqual (new []{ "d", "e" }));
				Assert.True (enumerable.ElementAt (4).SequenceEqual (new []{ "e" }));
			}

			{
				IEnumerable <IList<string>> enumerable = new []{ "a", "b", "c", "d", "e", "f", "g"}.Buffer (2, 3);
				Assert.That (enumerable.Count (), Is.EqualTo (3));
				Assert.True (enumerable.ElementAt (0).SequenceEqual (new []{ "a", "b" }));
				Assert.True (enumerable.ElementAt (1).SequenceEqual (new []{ "d", "e" }));
				Assert.True (enumerable.ElementAt (2).SequenceEqual (new []{ "g" }));
			}
		}
	}
}