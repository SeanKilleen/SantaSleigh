using Xunit;
using FluentAssertions;

namespace SantaSleighCode.Tests
{
    public class SantaSleighTests
    {
        [Fact]
        public void GetDirection_Default_FacingNorth()
        {
            var sut = new SantaSleigh();

            var result = sut.GetDirection();

            result.Should().Be("N");
        }

        [Fact]
        public void GetDirection_TurnRightOnce_FacingEast()
        {
            var sut = new SantaSleigh();

            sut.TurnRight();
            var result = sut.GetDirection();

            result.Should().Be("E");
        }

        [Fact]
        public void GetDirection_TurnRightTwoTimes_FacingSouth()
        {
            var sut = new SantaSleigh();

            sut.TurnRight();
            sut.TurnRight();
            var result = sut.GetDirection();

            result.Should().Be("S");
        }

        [Fact]
        public void GetDirection_TurnRightThreeTimes_FacingWest()
        {
            var sut = new SantaSleigh();

            sut.TurnRight();
            sut.TurnRight();
            sut.TurnRight();
            var result = sut.GetDirection();

            result.Should().Be("W");
        }

        [Fact]
        public void GetDirection_TurnRightFourTimes_FacingNorth()
        {
            var sut = new SantaSleigh();

            sut.TurnRight();
            sut.TurnRight();
            sut.TurnRight();
            sut.TurnRight();
            var result = sut.GetDirection();

            result.Should().Be("N");
        }
    }
}
