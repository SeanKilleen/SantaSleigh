using System.Collections.Generic;

public class SantaSleigh
{
    private LinkedList<string> _directionList = new LinkedList<string>(new string[] { "N", "E", "S", "W" });

    private string _direction;
    private int _xCoord = 0;
    private int _yCoord = 0;
    private int _gridSize;

    public SantaSleigh(int gridSize)
    {
        _direction = _directionList.First.Value;
        _gridSize = gridSize;
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
    }
    public void MoveForward(int spaces)
    {
        switch (_direction)
        {
            case "N":
                // Yeah, this took me a minute and there's probably a better way.
                // Check if we are going to go off the grid
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
