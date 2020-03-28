using System;

namespace RoversOnMars.Domain
{
    public class Plateau : IPlateau
    {
        private readonly int _maxX;
        private readonly int _maxY;

        public int MinX => 0;
        public int MinY => 0;

        private Plateau()
        {
        }

        public Plateau(int maxX, int maxY)
        {
            if (maxX < MinX || maxY < MinY || maxX == MinX && maxY == MinY)
            {
                throw new InvalidOperationException($"Invalid upper right boudandaries : ({maxX}, {maxY})");
            }

            _maxX = maxX;
            _maxY = maxY;
        }

        public bool IsLocationOnPlateau(int x, int y)
        {
            return x <= _maxX && y <= _maxY && x >= MinX && y >= MinY;
        }
    }
}