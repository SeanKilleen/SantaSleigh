using System;
using System.Collections.Generic;

namespace SantaSleighCode
{
    public class SantaSleigh
    {
        private LinkedList<string> _directionList = new LinkedList<string>(new string[] { "N", "E", "S", "W" });
        private string _direction;

        private int _xCoord = 0;

        public SantaSleigh()
        {
            _direction = _directionList.First.Value;
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

        public void MoveForward(int spaces)
        {
            _xCoord += spaces; // This will only work when facing East
        }
        public void MoveBackward(int spaces)
        {
            _xCoord -= spaces; // This will only work when facing East
        }
    }

}
