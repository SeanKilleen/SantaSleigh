public class SantaSleigh
{
    string _direction = "N";
    public string GetDirection()
    {
        return _direction;
    }

    public void TurnRight()
    {
        _direction = "E";
    }
}
