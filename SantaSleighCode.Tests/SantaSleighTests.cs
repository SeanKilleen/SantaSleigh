using System;
using NUnit.Framework;
using FluentAssertions;

namespace SantaSleighCode.Tests
{
    public class SantaSleighTests
    {
        private SantaSleigh _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new SantaSleigh();
        }

        [Test]
        public void GetDirection_Default_FacingNorth()
        {
            var result = _sut.GetDirection();

            result.Should().Be("N");
        }

        [Test]
        public void GetDirection_TurnRightOnce_FacingEast()
        {
            _sut.TurnRight();
            var result = _sut.GetDirection();

            result.Should().Be("E");
        }

        [Test]
        public void GetDirection_TurnRightTwice_FacingSouth()
        {
            _sut.TurnRight();
            _sut.TurnRight();
            var result = _sut.GetDirection();

            result.Should().Be("S");
        }

        [Test]
        public void GetDirection_TurnRightThreeTimes_FacingWest()
        {
            _sut.TurnRight();
            _sut.TurnRight();
            _sut.TurnRight();
            var result = _sut.GetDirection();

            result.Should().Be("W");
        }

        [Test]
        public void GetDirection_TurnRightFourTimes_FacingNorth()
        {
            _sut.TurnRight();
            _sut.TurnRight();
            _sut.TurnRight();
            _sut.TurnRight();
            var result = _sut.GetDirection();

            result.Should().Be("N");
        }

        [Test]
        public void GetDirection_TurnRightFiveTimes_FacingEast()
        {
            _sut.TurnRight();
            _sut.TurnRight();
            _sut.TurnRight();
            _sut.TurnRight();
            _sut.TurnRight();
            var result = _sut.GetDirection();

            result.Should().Be("E");
        }

        [Test]
        public void GetDirection_TurnLeftOneTime_FacingWest()
        {
            _sut.TurnLeft();
            var result = _sut.GetDirection();

            result.Should().Be("W");
        }

        [Test]
        public void GetDirection_TurnLeftTwoTimes_FacingSouth()
        {
            _sut.TurnLeft();
            _sut.TurnLeft();
            var result = _sut.GetDirection();

            result.Should().Be("S");
        }

        [Test]
        public void GetDirection_TurnLeftThreeTimes_FacingEast()
        {
            _sut.TurnLeft();
            _sut.TurnLeft();
            _sut.TurnLeft();
            var result = _sut.GetDirection();

            result.Should().Be("E");
        }

        [Test]
        public void GetDirection_TurnLeftFourTimes_FacingNorth()
        {
            _sut.TurnLeft();
            _sut.TurnLeft();
            _sut.TurnLeft();
            _sut.TurnLeft();
            var result = _sut.GetDirection();

            result.Should().Be("N");
        }

        [Test]
        public void GetDirection_TurnLeftFiveTimes_FacingWest()
        {
            _sut.TurnLeft();
            _sut.TurnLeft();
            _sut.TurnLeft();
            _sut.TurnLeft();
            _sut.TurnLeft();
            var result = _sut.GetDirection();

            result.Should().Be("W");
        }

        [Test]
        public void GetXCoordinate_Default_Zero()
        {
            var result = _sut.GetXCoordinate();

            result.Should().Be(0);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetXCoordinate_FacingEastAndMovingForward_IncreasesX(int numberOfSpaces)
        {
            _sut.TurnRight();

            _sut.MoveForward(numberOfSpaces);
            var result = _sut.GetXCoordinate();

            result.Should().Be(numberOfSpaces);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetXCoordinate_FacingEastAndMovingBackward_DecreasesX(int numberOfSpaces)
        {
            _sut.TurnRight();

            _sut.MoveBackward(numberOfSpaces);
            var result = _sut.GetXCoordinate();

            result.Should().Be(-numberOfSpaces);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetXCoordinate_FacingWestAndMovingForward_ReducesX(int numberOfSpaces)
        {
            _sut.TurnLeft();

            _sut.MoveForward(numberOfSpaces);
            var result = _sut.GetXCoordinate();

            result.Should().Be(-numberOfSpaces);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetXCoordinate_FacingWestAndMovingBackward_IncreasesX(int numberOfSpaces)
        {
            _sut.TurnLeft();

            _sut.MoveBackward(numberOfSpaces);
            var result = _sut.GetXCoordinate();

            result.Should().Be(numberOfSpaces);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetXCoordinate_FacingNorthAndMovingForward_NoChange(int numberOfSpaces)
        {
            _sut.MoveForward(numberOfSpaces);
            var result = _sut.GetXCoordinate();

            result.Should().Be(0);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetXCoordinate_FacingNorthAndMovingBackward_NoChange(int numberOfSpaces)
        {
            _sut.MoveBackward(numberOfSpaces);
            var result = _sut.GetXCoordinate();

            result.Should().Be(0);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetXCoordinate_FacingSouthAndMovingForward_NoChange(int numberOfSpaces)
        {
            _sut.TurnLeft();
            _sut.TurnLeft();

            _sut.MoveForward(numberOfSpaces);
            var result = _sut.GetXCoordinate();

            result.Should().Be(0);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetXCoordinate_FacingSouthAndMovingBackward_NoChange(int numberOfSpaces)
        {
            _sut.TurnLeft();
            _sut.TurnLeft();

            _sut.MoveBackward(numberOfSpaces);
            var result = _sut.GetXCoordinate();

            result.Should().Be(0);
        }

        [Test]
        public void GetYCoordinate_Default_Zero()
        {
            var result = _sut.GetYCoordinate();

            result.Should().Be(0);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetYCoordinate_FacingNorthAndMovingForward_IncreasesY(int numberOfSpaces)
        {
            _sut.MoveForward(numberOfSpaces);
            var result = _sut.GetYCoordinate();

            result.Should().Be(numberOfSpaces);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetYCoordinate_FacingNorthAndMovingBackward_DecreasesY(int numberOfSpaces)
        {
            _sut.MoveBackward(numberOfSpaces);
            var result = _sut.GetYCoordinate();

            result.Should().Be(-numberOfSpaces);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetYCoordinate_FacingSouthAndMovingForward_DecreasesY(int numberOfSpaces)
        {
            _sut.TurnLeft();
            _sut.TurnLeft();

            _sut.MoveForward(numberOfSpaces);
            var result = _sut.GetYCoordinate();

            result.Should().Be(-numberOfSpaces);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetYCoordinate_FacingSouthAndMovingBackward_IncreasesY(int numberOfSpaces)
        {
            _sut.TurnLeft();
            _sut.TurnLeft();

            _sut.MoveBackward(numberOfSpaces);
            var result = _sut.GetYCoordinate();

            result.Should().Be(numberOfSpaces);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetYCoordinate_FacingEastAndMovingForward_NoChange(int numberOfSpaces)
        {
            _sut.TurnRight();

            _sut.MoveForward(numberOfSpaces);
            var result = _sut.GetYCoordinate();

            result.Should().Be(0);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetYCoordinate_FacingEastAndMovingBackward_NoChange(int numberOfSpaces)
        {
            _sut.TurnRight();

            _sut.MoveBackward(numberOfSpaces);
            var result = _sut.GetYCoordinate();

            result.Should().Be(0);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetYCoordinate_FacingWestAndMovingForward_NoChange(int numberOfSpaces)
        {
            _sut.TurnLeft();

            _sut.MoveForward(numberOfSpaces);
            var result = _sut.GetYCoordinate();

            result.Should().Be(0);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(123)]
        public void GetYCoordinate_FacingWestAndMovingBackward_NoChange(int numberOfSpaces)
        {
            _sut.TurnLeft();

            _sut.MoveBackward(numberOfSpaces);
            var result = _sut.GetYCoordinate();

            result.Should().Be(0);
        }
    }
}