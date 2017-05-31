using NUnit.Framework;
using Should;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bogosoft.Qualification.Tests
{
    [TestFixture, Category("Unit")]
    public class UnitTests
    {
        [TestCase]
        public void CanFilterSequenceByQualifier()
        {
            var length = 128;

            var ints = Enumerable.Range(0, length);

            ints.Where(new EvenIntegerQualifier()).Count().ShouldEqual(length / 2);
        }
    }
}