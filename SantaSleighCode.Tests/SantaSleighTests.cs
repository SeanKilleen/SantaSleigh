using System;
using NUnit.Framework;
using FluentAssertions;

namespace SantaSleighCode.Tests
{
    public class SantaSleighTests
    {
        [Test]
        public void GetDirection_Default_FacingNorth()
        {
            var sut = new SantaSleigh();

            var result = sut.GetDirection();

            result.Should().Be("N");
        }

        [Test]
        public void GetDirection_TurnRightOnce_FacingEast()
        {
            var sut = new SantaSleigh();

            sut.TurnRight();
            var result = sut.GetDirection();

            result.Should().Be("E");
        }
    }
}