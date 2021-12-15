using Xunit;
using FluentAssertions;
using FsCheck.Xunit;
using FsCheck;
using System.Collections.Generic;

namespace SantaSleighCode.Tests
{
    public class SantaSleighTests
    {
        private SantaSleigh _sut;
        private const int GRID_SIZE = 124;
        private const int DUMMY_NUMBER_OF_PRESENTS = 5;
        private List<NeighborhoodHouse> DUMMY_EMPTY_HOUSE_LIST = new();

        public SantaSleighTests()
        {
            _sut = new SantaSleigh(GRID_SIZE, DUMMY_NUMBER_OF_PRESENTS, DUMMY_EMPTY_HOUSE_LIST);
        }

        [Fact]
        public void GetDirection_Default_FacingNorth()
        {
            var result = _sut.GetDirection();

            result.Should().Be("N");
        }

        [Fact]
        public void GetDirection_TurnRightOnce_FacingEast()
        {
            _sut.TurnRight();
            var result = _sut.GetDirection();

            result.Should().Be("E");
        }

        [Fact]
        public void GetDirection_TurnRightTwoTimes_FacingSouth()
        {
            _sut.TurnRight();
            _sut.TurnRight();
            var result = _sut.GetDirection();

            result.Should().Be("S");
        }

        [Fact]
        public void GetDirection_TurnRightThreeTimes_FacingWest()
        {
            _sut.TurnRight();
            _sut.TurnRight();
            _sut.TurnRight();
            var result = _sut.GetDirection();

            result.Should().Be("W");
        }

        [Fact]
        public void GetDirection_TurnRightFourTimes_FacingNorth()
        {
            _sut.TurnRight();
            _sut.TurnRight();
            _sut.TurnRight();
            _sut.TurnRight();
            var result = _sut.GetDirection();

            result.Should().Be("N");
        }

        [Fact]
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

        [Fact]
        public void GetDirection_TurnLeftOneTime_FacingWest()
        {
            _sut.TurnLeft();
            var result = _sut.GetDirection();

            result.Should().Be("W");
        }

        [Fact]
        public void GetDirection_TurnLeftTwoTimes_FacingSouth()
        {
            _sut.TurnLeft();
            _sut.TurnLeft();
            var result = _sut.GetDirection();

            result.Should().Be("S");
        }

        [Fact]
        public void GetDirection_TurnLeftThreeTimes_FacingEast()
        {
            _sut.TurnLeft();
            _sut.TurnLeft();
            _sut.TurnLeft();
            var result = _sut.GetDirection();

            result.Should().Be("E");
        }

        [Fact]
        public void GetDirection_TurnLeftFourTimes_FacingNorth()
        {
            _sut.TurnLeft();
            _sut.TurnLeft();
            _sut.TurnLeft();
            _sut.TurnLeft();
            var result = _sut.GetDirection();

            result.Should().Be("N");
        }

        [Fact]
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

        [Fact]
        public void GetXCoordinate_Default_Zero()
        {
            var result = _sut.GetXCoordinate();

            result.Should().Be(0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(123)]

        public void GetXCoordinate_FacingEastAndMovingForward_IncreasesX(int numberOfSpaces)
        {
            _sut.TurnRight();

            _sut.MoveForward(numberOfSpaces);
            var result = _sut.GetXCoordinate();

            result.Should().Be(numberOfSpaces);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(123)]
        public void GetXCoordinate_FacingEastAndMovingBackward_DecreasesX(int numberOfSpaces)
        {
            _sut.TurnRight();

            _sut.MoveBackward(numberOfSpaces);
            var result = _sut.GetXCoordinate();

            result.Should().Be(-numberOfSpaces);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(123)]
        public void GetXCoordinate_FacingWestAndMovingForward_DecreasesX(int numberOfSpaces)
        {
            _sut.TurnLeft();

            _sut.MoveForward(numberOfSpaces);
            var result = _sut.GetXCoordinate();

            result.Should().Be(-numberOfSpaces);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(123)]
        public void GetXCoordinate_FacingWestAndMovingBackward_IncreasesX(int numberOfSpaces)
        {
            _sut.TurnLeft();

            _sut.MoveBackward(numberOfSpaces);
            var result = _sut.GetXCoordinate();

            result.Should().Be(numberOfSpaces);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(123)]
        public void GetXCoordinate_FacingNorthAndMovingForward_NoChange(int numberOfSpaces)
        {
            _sut.MoveForward(numberOfSpaces);
            var result = _sut.GetXCoordinate();

            result.Should().Be(0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(123)]
        public void GetXCoordinate_FacingNorthAndMovingBackward_NoChange(int numberOfSpaces)
        {
            _sut.MoveBackward(numberOfSpaces);
            var result = _sut.GetXCoordinate();

            result.Should().Be(0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(123)]
        public void GetXCoordinate_FacingSouthAndMovingForward_NoChange(int numberOfSpaces)
        {
            _sut.TurnLeft();
            _sut.TurnLeft();

            _sut.MoveForward(numberOfSpaces);
            var result = _sut.GetXCoordinate();

            result.Should().Be(0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(123)]
        public void GetXCoordinate_FacingSouthAndMovingBackward_NoChange(int numberOfSpaces)
        {
            _sut.TurnLeft();
            _sut.TurnLeft();

            _sut.MoveBackward(numberOfSpaces);
            var result = _sut.GetXCoordinate();

            result.Should().Be(0);
        }

        [Fact]
        public void GetYCoordinate_Default_Zero()
        {
            var result = _sut.GetYCoordinate();

            result.Should().Be(0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(123)]

        public void GetYCoordinate_FacingNorthAndMovingForward_IncreasesY(int numberOfSpaces)
        {
            _sut.MoveForward(numberOfSpaces);
            var result = _sut.GetYCoordinate();

            result.Should().Be(numberOfSpaces);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(123)]
        public void GetYCoordinate_FacingNorthAndMovingBackward_DecreasesY(int numberOfSpaces)
        {
            _sut.MoveBackward(numberOfSpaces);
            var result = _sut.GetYCoordinate();

            result.Should().Be(-numberOfSpaces);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(123)]
        public void GetYCoordinate_FacingSouthAndMovingForward_DecreasesY(int numberOfSpaces)
        {
            _sut.TurnLeft();
            _sut.TurnLeft();

            _sut.MoveForward(numberOfSpaces);
            var result = _sut.GetYCoordinate();

            result.Should().Be(-numberOfSpaces);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(123)]
        public void GetYCoordinate_FacingSouthAndMovingBackward_IncreasesY(int numberOfSpaces)
        {
            _sut.TurnLeft();
            _sut.TurnLeft();

            _sut.MoveBackward(numberOfSpaces);
            var result = _sut.GetYCoordinate();

            result.Should().Be(numberOfSpaces);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(123)]
        public void GetYCoordinate_FacingEastAndMovingForward_NoChange(int numberOfSpaces)
        {
            _sut.TurnRight();

            _sut.MoveForward(numberOfSpaces);
            var result = _sut.GetYCoordinate();

            result.Should().Be(0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(123)]
        public void GetYCoordinate_FacingEastAndMovingBackward_NoChange(int numberOfSpaces)
        {
            _sut.TurnRight();

            _sut.MoveBackward(numberOfSpaces);
            var result = _sut.GetYCoordinate();

            result.Should().Be(0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(123)]
        public void GetYCoordinate_FacingWestAndMovingForward_NoChange(int numberOfSpaces)
        {
            _sut.TurnLeft();

            _sut.MoveForward(numberOfSpaces);
            var result = _sut.GetYCoordinate();

            result.Should().Be(0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(123)]
        public void GetYCoordinate_FacingWestAndMovingBackward_NoChange(int numberOfSpaces)
        {
            _sut.TurnLeft();

            _sut.MoveBackward(numberOfSpaces);
            var result = _sut.GetYCoordinate();

            result.Should().Be(0);
        }

        [Property]
        public void GetYCoordinate_FacingNorthMovingForwardPastEdgeByOne_MinimumYValue(PositiveInt randomSize)
        {
            var gridSize = ((int)randomSize);
            var sut = new SantaSleigh(gridSize, DUMMY_NUMBER_OF_PRESENTS, DUMMY_EMPTY_HOUSE_LIST);
            sut.MoveForward(gridSize + 1);
            var result = sut.GetYCoordinate();

            result.Should().Be(-gridSize);
        }

        [Property]
        public void GetXCoordinate_FacingEastMovingForwardPastEdgeByOne_MinimumXValue(PositiveInt randomSize)
        {
            var gridSize = ((int)randomSize);
            var sut = new SantaSleigh(gridSize, DUMMY_NUMBER_OF_PRESENTS, DUMMY_EMPTY_HOUSE_LIST);
            sut.TurnRight();

            sut.MoveForward(gridSize + 1);
            var result = sut.GetXCoordinate();

            result.Should().Be(-gridSize);
        }

        [Property]
        public void GetYCoordinate_FacingSouthMovingBackwardPastEdgeByOne_MinimumYValue(PositiveInt randomSize)
        {
            var gridSize = ((int)randomSize);
            var sut = new SantaSleigh(gridSize, DUMMY_NUMBER_OF_PRESENTS, DUMMY_EMPTY_HOUSE_LIST);
            sut.TurnLeft();
            sut.TurnLeft();

            sut.MoveBackward(gridSize + 1);
            var result = sut.GetYCoordinate();

            result.Should().Be(-gridSize);
        }

        [Property]
        public void GetXCoordinate_FacingWestMovingBackwardPastEdgeByOne_MinimumXValue(PositiveInt randomSize)
        {
            var gridSize = ((int)randomSize);
            var sut = new SantaSleigh(gridSize, DUMMY_NUMBER_OF_PRESENTS, DUMMY_EMPTY_HOUSE_LIST);
            sut.TurnLeft();

            sut.MoveBackward(gridSize + 1);
            var result = sut.GetXCoordinate();

            result.Should().Be(-gridSize);
        }

        [Property]
        public void GetXCoordinate_FacingWestMovingForwardPastEdgeByOne_MaximumXValue(PositiveInt randomSize)
        {
            var gridSize = ((int)randomSize);
            var sut = new SantaSleigh(gridSize, DUMMY_NUMBER_OF_PRESENTS, DUMMY_EMPTY_HOUSE_LIST);
            sut.TurnLeft();

            sut.MoveForward(gridSize + 1);
            var result = sut.GetXCoordinate();

            result.Should().Be(gridSize);
        }

        [Property]
        public void GetYCoordinate_FacingSouthMovingForwardPastEdgeByOne_MaximumYValue(PositiveInt randomSize)
        {
            var gridSize = ((int)randomSize);
            var sut = new SantaSleigh(gridSize, DUMMY_NUMBER_OF_PRESENTS, DUMMY_EMPTY_HOUSE_LIST);
            sut.TurnLeft();
            sut.TurnLeft();

            sut.MoveForward(gridSize + 1);
            var result = sut.GetYCoordinate();

            result.Should().Be(gridSize);
        }

        [Property]
        public void GetYCoordinate_FacingNorthMovingBackwardPastEdgeByOne_MaximumYValue(PositiveInt randomSize)
        {
            var gridSize = ((int)randomSize);
            var sut = new SantaSleigh(gridSize, DUMMY_NUMBER_OF_PRESENTS, DUMMY_EMPTY_HOUSE_LIST);

            sut.MoveBackward(gridSize + 1);
            var result = sut.GetYCoordinate();

            result.Should().Be(gridSize);
        }

        [Property]
        public void GetXCoordinate_FacingEastMovingBackwardPastEdgeByOne_MaximumXValue(PositiveInt randomSize)
        {
            var gridSize = ((int)randomSize);
            var sut = new SantaSleigh(gridSize, DUMMY_NUMBER_OF_PRESENTS, DUMMY_EMPTY_HOUSE_LIST);
            sut.TurnRight();

            sut.MoveBackward(gridSize + 1);
            var result = sut.GetXCoordinate();

            result.Should().Be(gridSize);
        }

        [Property]
        public void GetDirection_AfterRandomTurnsAndWrappingAround_StillTheSame(PositiveInt randomSize, NonNegativeInt numberOfTurns)
        {
            var gridSize = ((int)randomSize);
            var sut = new SantaSleigh(gridSize, DUMMY_NUMBER_OF_PRESENTS, DUMMY_EMPTY_HOUSE_LIST);
            foreach (var i in System.Linq.Enumerable.Range(0, (int)numberOfTurns))
            {
                sut.TurnLeft();
            }
            var startingDirection = sut.GetDirection();

            sut.MoveForward(gridSize + 1);
            var result = sut.GetDirection();

            result.Should().Be(startingDirection);
        }

        [Property]
        public void RemainingPresents_Default_EqualsWhatWasPutIn(NonNegativeInt numberOfPresents)
        {
            var dummyGridSize = 5;
            var sut = new SantaSleigh(dummyGridSize, (int)numberOfPresents, DUMMY_EMPTY_HOUSE_LIST);

            var result = sut.RemainingPresents();

            result.Should().Be((int)numberOfPresents);
        }

        [Fact]
        public void RemainingPresents_WhenStoppingOverCoordinateThatIsntInPresentsList_StaysTheSame()
        {
            var dummyGridSize = 5;
            var sut = new SantaSleigh(dummyGridSize, DUMMY_NUMBER_OF_PRESENTS, DUMMY_EMPTY_HOUSE_LIST);

            sut.MoveForward(1);

            var result = sut.RemainingPresents();
            result.Should().Be(DUMMY_NUMBER_OF_PRESENTS);
        }

        [Fact]
        public void RemainingPresents_WhenStoppingOverHouseThatRequestsZeroPresents_StaysTheSame()
        {
            var gridSize = 5;
            var house = new NeighborhoodHouse(1, 1, 0);
            var houseList = new List<NeighborhoodHouse> { house };
            var sut = new SantaSleigh(gridSize, DUMMY_NUMBER_OF_PRESENTS, houseList);

            sut.MoveForward(1); // now at 1 on y axis
            sut.TurnRight();
            sut.MoveForward(1); // now at 1 on x axis

            var result = sut.RemainingPresents();
            result.Should().Be(DUMMY_NUMBER_OF_PRESENTS);
        }

        [Property]
        public void RemainingPresents_WhenFlyingOverAHouseThatRequestsPresents_WillBeReducedByOneMoreThanAskedFor(PositiveInt numberOfRequestedPresents)
        {
            var gridSize = 5;
            var totalPresents = (int)numberOfRequestedPresents + 1;
            var house = new NeighborhoodHouse(1, 1, (int)numberOfRequestedPresents);
            var houseList = new List<NeighborhoodHouse> { house };
            var sut = new SantaSleigh(gridSize, totalPresents, houseList);

            sut.MoveForward(1); // now at 1 on y axis
            sut.TurnRight();
            sut.MoveForward(1); // now at 1 on x axis

            var result = sut.RemainingPresents();
            result.Should().Be(0);
        }

        [Property]
        public void RemainingPresents_WhenBackingOverAHouseThatRequestsPresents_WillBeReducedByOneMoreThanAskedFor(PositiveInt numberOfRequestedPresents)
        {
            var gridSize = 5;
            var totalPresents = (int)numberOfRequestedPresents + 1;
            var house = new NeighborhoodHouse(1, 1, (int)numberOfRequestedPresents);
            var houseList = new List<NeighborhoodHouse> { house };
            var sut = new SantaSleigh(gridSize, totalPresents, houseList);

            sut.MoveForward(1); // now at 1 on y axis
            sut.TurnLeft();
            sut.MoveBackward(1); // now at 1 on x axis

            var result = sut.RemainingPresents();
            result.Should().Be(0);
        }

        [Fact]
        public void RemainingPresents_WhenStoppingOverMultipleHouses_ReducesAsExpected()
        {
            var gridSize = 5;
            var totalPresents = 10;
            var house1 = new NeighborhoodHouse(0, 1, 2);
            var house2 = new NeighborhoodHouse(0, 2, 3);
            var houseList = new List<NeighborhoodHouse> { house1, house2 };
            var sut = new SantaSleigh(gridSize, totalPresents, houseList);

            sut.MoveForward(1); // now at 1 on y axis, dropping 2 + 1 = 3 presents
            sut.MoveForward(1); // now at 2 on y axis, dropping 3 + 1 = 4 presents

            var result = sut.RemainingPresents();
            result.Should().Be(3);
        }

        [Fact]
        public void RemainingPresents_WhenStoppingOverAHouseTwice_OnlyDecrementsTheFirstTime()
        {
            var gridSize = 5;
            var totalPresents = 10;
            var house1 = new NeighborhoodHouse(0, 1, 2);
            var houseList = new List<NeighborhoodHouse> { house1 };
            var sut = new SantaSleigh(gridSize, totalPresents, houseList);

            sut.MoveForward(1); // now at 1 on y axis, dropping 2 + 1 = 3 presents
            sut.MoveForward(1); // going past the location
            sut.MoveBackward(1); // going back to the location

            var result = sut.RemainingPresents();
            result.Should().Be(7);
        }

    }
}
