using System;

namespace SantaSleighCode
{
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
            }
            else if (_direction == "E")
            {
                _direction = "S";
            }
            else if (_direction == "S")
            {
                _direction = "W";
            }
        }
    }
}
