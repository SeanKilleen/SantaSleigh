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
    }
}