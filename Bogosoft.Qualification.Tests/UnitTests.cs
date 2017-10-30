using NUnit.Framework;
using Should;
using System.Collections.Generic;
using System.Linq;

namespace Bogosoft.Qualification.Tests
{
    [TestFixture, Category("Unit")]
    public class UnitTests
    {
        static bool ContainsOddNumbers(IEnumerable<int> ints)
        {
            foreach(var x in ints)
            {
                if(x % 2 == 0)
                {
                    return true;
                }
            }

            return false;
        }

        [TestCase]
        public void CanFilterSequenceByQualifier()
        {
            var length = 128;

            var ints = Enumerable.Range(0, length);

            ints.Where(new EvenIntegerQualifier()).Count().ShouldEqual(length / 2);
        }
    }
}