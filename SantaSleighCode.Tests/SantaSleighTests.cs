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

        [Test]
        public void GetDirection_TurnRightTwice_FacingSouth()
        {
            var sut = new SantaSleigh();

            sut.TurnRight();
            sut.TurnRight();
            var result = sut.GetDirection();

            result.Should().Be("S");
        }

        [Test]
        public void GetDirection_TurnRightThreeTimes_FacingWest()
        {
            var sut = new SantaSleigh();

            sut.TurnRight();
            sut.TurnRight();
            sut.TurnRight();
            var result = sut.GetDirection();

            result.Should().Be("W");
        }

        [Test]
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

        [Test]
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

        [Test]
        public void GetDirection_TurnLeftOneTime_FacingWest()
        {
            var sut = new SantaSleigh();

            sut.TurnLeft();
            var result = sut.GetDirection();

            result.Should().Be("W");
        }

        [Test]
        public void GetDirection_TurnLeftTwoTimes_FacingSouth()
        {
            var sut = new SantaSleigh();

            sut.TurnLeft();
            sut.TurnLeft();
            var result = sut.GetDirection();

            result.Should().Be("S");
        }

        [Test]
        public void GetDirection_TurnLeftThreeTimes_FacingEast()
        {
            var sut = new SantaSleigh();

            sut.TurnLeft();
            sut.TurnLeft();
            sut.TurnLeft();
            var result = sut.GetDirection();

            result.Should().Be("E");
        }
        [Test]
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
        [Test]
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

        [Test]
        public void GetXCoordinate_Default_Zero()
        {
            var sut = new SantaSleigh();

            var result = sut.GetXCoordinate();

            result.Should().Be(0);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetXCoordinate_FacingEastAndMovingForward_IncreasesX(int numberOfSpaces)
        {
            var sut = new SantaSleigh();
            sut.TurnRight();

            sut.MoveForward(numberOfSpaces);
            var result = sut.GetXCoordinate();

            result.Should().Be(numberOfSpaces);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetXCoordinate_FacingEastAndMovingBackward_DecreasesX(int numberOfSpaces)
        {
            var sut = new SantaSleigh();
            sut.TurnRight();

            sut.MoveBackward(numberOfSpaces);
            var result = sut.GetXCoordinate();

            result.Should().Be(-numberOfSpaces);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetXCoordinate_FacingWestAndMovingForward_ReducesX(int numberOfSpaces)
        {
            var sut = new SantaSleigh();
            sut.TurnLeft();

            sut.MoveForward(numberOfSpaces);
            var result = sut.GetXCoordinate();

            result.Should().Be(-numberOfSpaces);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetXCoordinate_FacingWestAndMovingBackward_IncreasesX(int numberOfSpaces)
        {
            var sut = new SantaSleigh();
            sut.TurnLeft();

            sut.MoveBackward(numberOfSpaces);
            var result = sut.GetXCoordinate();

            result.Should().Be(numberOfSpaces);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetXCoordinate_FacingNorthAndMovingForward_NoChange(int numberOfSpaces)
        {
            var sut = new SantaSleigh();

            sut.MoveForward(numberOfSpaces);
            var result = sut.GetXCoordinate();

            result.Should().Be(0);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetXCoordinate_FacingNorthAndMovingBackward_NoChange(int numberOfSpaces)
        {
            var sut = new SantaSleigh();

            sut.MoveBackward(numberOfSpaces);
            var result = sut.GetXCoordinate();

            result.Should().Be(0);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetXCoordinate_FacingSouthAndMovingForward_NoChange(int numberOfSpaces)
        {
            var sut = new SantaSleigh();
            sut.TurnLeft();
            sut.TurnLeft();

            sut.MoveForward(numberOfSpaces);
            var result = sut.GetXCoordinate();

            result.Should().Be(0);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetXCoordinate_FacingSouthAndMovingBackward_NoChange(int numberOfSpaces)
        {
            var sut = new SantaSleigh();
            sut.TurnLeft();
            sut.TurnLeft();

            sut.MoveBackward(numberOfSpaces);
            var result = sut.GetXCoordinate();

            result.Should().Be(0);
        }

        [Test]
        public void GetYCoordinate_Default_Zero()
        {
            var sut = new SantaSleigh();

            var result = sut.GetYCoordinate();

            result.Should().Be(0);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetYCoordinate_FacingNorthAndMovingForward_IncreasesY(int numberOfSpaces)
        {
            var sut = new SantaSleigh();

            sut.MoveForward(numberOfSpaces);
            var result = sut.GetYCoordinate();

            result.Should().Be(numberOfSpaces);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetYCoordinate_FacingNorthAndMovingBackward_DecreasesY(int numberOfSpaces)
        {
            var sut = new SantaSleigh();

            sut.MoveBackward(numberOfSpaces);
            var result = sut.GetYCoordinate();

            result.Should().Be(-numberOfSpaces);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetYCoordinate_FacingSouthAndMovingForward_DecreasesY(int numberOfSpaces)
        {
            var sut = new SantaSleigh();
            sut.TurnLeft();
            sut.TurnLeft();

            sut.MoveForward(numberOfSpaces);
            var result = sut.GetYCoordinate();

            result.Should().Be(-numberOfSpaces);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetYCoordinate_FacingSouthAndMovingBackward_IncreasesY(int numberOfSpaces)
        {
            var sut = new SantaSleigh();
            sut.TurnLeft();
            sut.TurnLeft();

            sut.MoveBackward(numberOfSpaces);
            var result = sut.GetYCoordinate();

            result.Should().Be(numberOfSpaces);
        }
    }
}