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
            _direction = "E";
        }
    }
}
