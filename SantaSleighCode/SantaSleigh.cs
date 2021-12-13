using System.Collections.Generic;
using System.Linq;

public class SantaSleigh
{
    private LinkedList<string> _directionList = new LinkedList<string>(new string[] { "N", "E", "S", "W" });
    private int _xCoord = 0;
    private int _yCoord = 0;

    private int _numberOfPresents;
    private string _direction;
    private int _gridSize;
    private List<NeighborhoodHouse> _neighborhoodHouses;

    public SantaSleigh(int gridSize, int numberOfPresents, List<NeighborhoodHouse> houses)
    {
        _direction = _directionList.First.Value;
        _gridSize = gridSize;
        _numberOfPresents = numberOfPresents;
        _neighborhoodHouses = houses;
    }

    public string GetDirection()
    {
        return _direction;
    }

    public void TurnRight()
    {
        if (_direction == _directionList.Last.Value)
        {
            _direction = _directionList.First.Value;
            return;
        }

        _direction = _directionList.Find(_direction).Next.Value;
        return;
    }

    public void TurnLeft()
    {
        if (_direction == _directionList.First.Value)
        {
            _direction = _directionList.Last.Value;
            return;
        }

        _direction = _directionList.Find(_direction).Previous.Value;
        return;
    }

    public int GetXCoordinate()
    {
        return _xCoord;
    }

    public int GetYCoordinate()
    {
        return _yCoord;
    }

    public int RemainingPresents()
    {
        return _numberOfPresents;
    }

    public void MoveBackward(int spaces)
    {
        switch (_direction)
        {
            case "N":
                _yCoord = DecreaseCoordinateAgainstGridSize(_yCoord, spaces, _gridSize);
                break;
            case "E":
                _xCoord = DecreaseCoordinateAgainstGridSize(_xCoord, spaces, _gridSize);
                break;
            case "S":
                _yCoord = IncreaseCoordinateAgainstGridSize(_yCoord, spaces, _gridSize);
                break;
            case "W":
                _xCoord = IncreaseCoordinateAgainstGridSize(_xCoord, spaces, _gridSize);
                break;
        }

        var matchingHouse = _neighborhoodHouses.SingleOrDefault(house => house.X == _xCoord && house.Y == _yCoord);
        if (matchingHouse != null && matchingHouse.RequestedPresents > 0)
        {
            var magicalExtraPresents = 1;
            _numberOfPresents -= (matchingHouse.RequestedPresents + magicalExtraPresents);
        }
    }
    public void MoveForward(int spaces)
    {
        switch (_direction)
        {
            case "N":
                _yCoord = IncreaseCoordinateAgainstGridSize(_yCoord, spaces, _gridSize);
                break;
            case "E":
                _xCoord = IncreaseCoordinateAgainstGridSize(_xCoord, spaces, _gridSize);
                break;
            case "S":
                _yCoord = DecreaseCoordinateAgainstGridSize(_yCoord, spaces, _gridSize);
                break;
            case "W":
                _xCoord = DecreaseCoordinateAgainstGridSize(_xCoord, spaces, _gridSize);
                break;
        }

        var matchingHouse = _neighborhoodHouses.SingleOrDefault(house => house.X == _xCoord && house.Y == _yCoord);
        if (matchingHouse != null && matchingHouse.RequestedPresents > 0)
        {
            var magicalExtraPresents = 1;
            _numberOfPresents -= (matchingHouse.RequestedPresents + magicalExtraPresents);
        }
    }

    private int IncreaseCoordinateAgainstGridSize(int coord, int spaces, int gridSize)
    {
        if (coord + spaces > gridSize)
        {
            // Get how many spaces off we'd be
            var spacesOffTheGrid = (coord + spaces) - gridSize;
            return (-gridSize) + spacesOffTheGrid - 1;
        }
        else
        {
            return coord += spaces;
        };
    }
    private int DecreaseCoordinateAgainstGridSize(int coord, int spaces, int gridSize)
    {
        if (coord - spaces < -gridSize)
        {
            // Get how many spaces off we'd be
            var spacesOffTheGrid = (coord - spaces) + gridSize;
            return (gridSize) + spacesOffTheGrid + 1;
        }
        else
        {
            return coord -= spaces;
        };
    }

}

public record NeighborhoodHouse(int X, int Y, int RequestedPresents);
