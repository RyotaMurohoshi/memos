using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace ix_example
{
	[TestFixture ()]
	public class ReturnTest
	{
		[Test ()]
		public void TestReturnIntCase ()
		{
			IEnumerable <int> intEnumerable = EnumerableEx.Return (0);
			Assert.That (intEnumerable.Count (), Is.EqualTo (1));
			Assert.That (intEnumerable.First (), Is.EqualTo (0));
		}

		[Test ()]
		public void TestReturnStringCase ()
		{
			IEnumerable <string> stringEnumerable = EnumerableEx.Return ("test with return");
			Assert.That (stringEnumerable.Count (), Is.EqualTo (1));
			Assert.That (stringEnumerable.First (), Is.EqualTo ("test with return"));
		}
	}
}
