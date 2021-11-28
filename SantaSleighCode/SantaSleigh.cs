public class SantaSleigh
{
    private string _direction = "N";

    public string GetDirection()
    {
        return _direction;
    }

    public void TurnRight()
    {
        if (_direction == "N")
        {
            _direction = "E";
            return;
        }
        if (_direction == "E")
        {
            _direction = "S";
            return;
        }
        if (_direction == "S")
        {
            _direction = "W";
            return;
        }
        if (_direction == "W")
        {
            _direction = "N";
            return;
        }
    }
}
