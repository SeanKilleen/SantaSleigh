using System;
using NUnit.Framework;

namespace SantaSleighCode.Tests
{
    public class BasicTest
    {
        [Test]
        public void MathStillWorks()
        {
            var result = 1 + 1;

            Assert.That(result, Is.EqualTo(2));
        }
    }
}