using System;

namespace RoversOnMars
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
            if (maxX < 0 || maxY < 0 || maxX == 0 && maxY == 0)
            {
                throw new InvalidOperationException($"Invalid boudandaries upper right : ({maxX}, {maxY})");
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