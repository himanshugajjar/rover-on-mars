using System;
using Xunit;
using RoversOnMars.Domain;

namespace RoversOnMars.Tests
{
    public class PlateauTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(5, 5)]
        public void SetPlateauBoundary_Test(int maxX, int maxY)
        {
            // arrange and action
            var plateau = new Plateau(maxX, maxY);

            // assert
            Assert.NotNull(plateau);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, 2)]
        [InlineData(-1, -2)]
        public void SetInvalidPlateauBoundary_Test(int maxX, int maxY)
        {
            Assert.Throws<InvalidOperationException>(() => new Plateau(maxX, maxY));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, 2)]
        [InlineData(-1, -2)]
        public void IsRoverInBoundary_Test(int x, int y)
        {
            // arrange
            var maxX = 5;
            var maxY = 5;

            var plateau = new Plateau(maxX, maxY);

            //action
            var result = plateau.IsLocationOnPlateau(x, y);

            // assert
            if (x >= maxX || y >= maxY || (x == 0 && y == 0))
            {
                Assert.True(result);
            }
            else
            {
                Assert.False(result);
            }
        }

    }
}
