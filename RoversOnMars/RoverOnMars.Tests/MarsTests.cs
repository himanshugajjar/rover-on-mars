using RoversOnMars.Domain;
using RoversOnMars.Enums;
using RoversOnMars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RoversOnMars.Tests
{
    public class MarsTests
    {
        readonly IPlateau _plateau;
        readonly List<Location> _locations;

        public MarsTests()
        {
            _plateau = new Plateau(100, 100);

            _locations = new List<Location> {
                new Location(1, 2, Orientation.N),
                new Location(2, 2, Orientation.E),
                new Location(3, 4, Orientation.W),
                new Location(5, 2, Orientation.S),
                new Location(1, 6, Orientation.W),
                new Location(6, 2, Orientation.E),
                new Location(6, 2, Orientation.N),
                new Location(7, 2, Orientation.N),
                new Location(1, 7, Orientation.S),
                new Location(8, 8, Orientation.N),
                new Location(1, 9, Orientation.W),
                new Location(10, 10, Orientation.N)
            };
        }

        [Fact]
        public void DeployRovers_on_Mars()
        {
            // arrange
            var mars = new Mars(_plateau);

            // action
            var result = mars.DeployRovers(_locations);

            //assert
            Assert.NotNull(result);

            var robots = result.ToList();

            Assert.Equal(_locations.Count, robots.Count);
        }

        [Fact]
        public void Move_rover_on_Mars()
        {
            // arrange
            var mars = new Mars(_plateau);
            var results = new List<Location>();

            // action
            var robotIds = mars.DeployRovers(_locations).ToList();

            robotIds.ForEach(x => results.Add(mars.MoveRobot(x, "M")));

            //assert
            Assert.NotNull(results);

            Assert.Equal(_locations.Count, robotIds.Count);

            Assert.Equal(_locations.Count, results.Count);

            for (var i = 0; i < _locations.Count; i++)
            {
                Assert.Equal(_locations[i].Orientation, results[i].Orientation);

                switch (_locations[i].Orientation)
                {
                    case Orientation.N:
                        {
                            Assert.Equal(_locations[i].X, results[i].X);

                            Assert.Equal(_locations[i].Y + 1, results[i].Y);
                        }
                        break;
                    case Orientation.E:
                        {
                            Assert.Equal(_locations[i].X + 1, results[i].X);

                            Assert.Equal(_locations[i].Y, results[i].Y);
                        }
                        break;
                    case Orientation.S:
                        {
                            Assert.Equal(_locations[i].X, results[i].X);

                            Assert.Equal(_locations[i].Y - 1, results[i].Y);
                        }
                        break;
                    case Orientation.W:
                        {
                            Assert.Equal(_locations[i].X - 1, results[i].X);

                            Assert.Equal(_locations[i].Y, results[i].Y);
                        }
                        break;
                };

            }
        }

        [Fact]
        public void Move_invalid_rover_on_Mars()
        {
            // arrange
            var mars = new Mars(_plateau);

            // action
            var robotIds = mars.DeployRovers(_locations).ToList();

            var result = mars.MoveRobot(Guid.NewGuid(), "LLMMMM");

            //assert
            Assert.Null(result);

        }

        [Fact]
        public void Move_invalid_location_rover_on_Mars()
        {
            // arrange
            var mars = new Mars(_plateau);

            //assert
            Assert.Throws<InvalidOperationException>(() => mars.DeployRovers(new List<Location> { new Location(1, 1000, Orientation.N)}));

        }

        [Theory]
        [InlineData(5, 5, 1, 2, Orientation.N, "LMLMLMLMM", "1 3 N")]
        [InlineData(5, 5, 3, 3, Orientation.E, "MMRMMRMRRM", "5 1 E")]
        public void Move_rover_on_Mars_acceptance_tests(int maxX, int maxY, int x, int y, Orientation ori, string direction, string finalLocation)
        {
            // arrange
            var mars = new Mars(new Plateau(maxX, maxY));

            // action
            var robotIds = mars.DeployRovers(new List<Location> { new Location(x, y, ori)}).ToList();

            var result = mars.MoveRobot(robotIds.First(), direction);

            //assert
            Assert.Equal(finalLocation, result.ToString());

        }

    }
}
