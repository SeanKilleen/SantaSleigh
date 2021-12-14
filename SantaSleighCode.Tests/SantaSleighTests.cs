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

        [Fact]
        public void GetDirection_TurnRightFiveTimes_FacingEast()
        {
            var sut = new SantaSleigh();

            sut.TurnRight();
            sut.TurnRight();
            sut.TurnRight();
            sut.TurnRight();
            sut.TurnRight();
            var result = sut.GetDirection();

            result.Should().Be("E");
        }

        [Fact]
        public void GetDirection_TurnLeftOneTime_FacingWest()
        {
            var sut = new SantaSleigh();

            sut.TurnLeft();
            var result = sut.GetDirection();

            result.Should().Be("W");
        }

        [Fact]
        public void GetDirection_TurnLeftTwoTimes_FacingSouth()
        {
            var sut = new SantaSleigh();

            sut.TurnLeft();
            sut.TurnLeft();
            var result = sut.GetDirection();

            result.Should().Be("S");
        }

        [Fact]
        public void GetDirection_TurnLeftThreeTimes_FacingEast()
        {
            var sut = new SantaSleigh();

            sut.TurnLeft();
            sut.TurnLeft();
            sut.TurnLeft();
            var result = sut.GetDirection();

            result.Should().Be("E");
        }

        [Fact]
        public void GetDirection_TurnLeftFourTimes_FacingNorth()
        {
            var sut = new SantaSleigh();

            sut.TurnLeft();
            sut.TurnLeft();
            sut.TurnLeft();
            sut.TurnLeft();
            var result = sut.GetDirection();

            result.Should().Be("N");
        }

        [Fact]
        public void GetDirection_TurnLeftFiveTimes_FacingWest()
        {
            var sut = new SantaSleigh();

            sut.TurnLeft();
            sut.TurnLeft();
            sut.TurnLeft();
            sut.TurnLeft();
            sut.TurnLeft();
            var result = sut.GetDirection();

            result.Should().Be("W");
        }

        [Fact]
        public void GetXCoordinate_Default_Zero()
        {
            var sut = new SantaSleigh();

            var result = sut.GetXCoordinate();

            result.Should().Be(0);
        }

        [Fact]
        public void GetXCoordinate_FacingEastAndMovingForward_One()
        {
            var sut = new SantaSleigh();
            sut.TurnRight();

            sut.MoveForward(1);
            var result = sut.GetXCoordinate();

            result.Should().Be(1);
        }

        [Fact]
        public void GetXCoordinate_FacingEastAndMovingBackward_NegativeOne()
        {
            var sut = new SantaSleigh();
            sut.TurnRight();

            sut.MoveBackward(1);
            var result = sut.GetXCoordinate();

            result.Should().Be(-1);
        }

    }
}
