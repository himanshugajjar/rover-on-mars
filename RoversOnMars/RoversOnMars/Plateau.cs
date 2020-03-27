﻿using System;

namespace RoversOnMars
{
    public class Plateau
    {
        private readonly int _maxX;
        private readonly int _maxY;

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
    }
}