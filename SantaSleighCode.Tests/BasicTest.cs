using System;
using Xunit;

namespace SantaSleighCode.Tests
{
    public class Class1
    {
        [Fact]
        public void MathStillWorks()
        {
            var result = 1 + 1;

            Assert.Equal(2, result);
        }
    }
}
