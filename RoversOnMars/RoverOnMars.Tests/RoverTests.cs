using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RoversOnMars.Tests
{
    public class RoverTests
    {
        [Fact]
        public void RoverMustHaveDefault_Location_0_0()
        {
            // arrange
            var rover = new Rover();

            // action
            var location = rover.CurrentLocation;

            // assert
            Assert.NotNull(location);

            Assert.Equal(0, location.X);

            Assert.Equal(0, location.Y);

            Assert.Equal('N', location.Direction);
        }

        [Fact]
        public void Rover_can_turn_left()
        {
            // arrange
            var rover = new Rover();

            // action
            var location = rover.Move("L");

            // assert
            Assert.NotNull(location);

            Assert.Equal(0, location.X);

            Assert.Equal(0, location.Y);

            Assert.Equal('E', location.Direction);
        }

        [Fact]
        public void Rover_can_turn_right()
        {
            // arrange
            var rover = new Rover();

            // action
            var location = rover.Move("R");

            // assert
            Assert.NotNull(location);

            Assert.Equal(0, location.X);

            Assert.Equal(0, location.Y);

            Assert.Equal('W', location.Direction);
        }

        [Fact]
        public void Rover_can_move_forward()
        {
            // arrange
            var rover = new Rover();

            // action
            var location = rover.Move("M");

            // assert
            Assert.NotNull(location);

            Assert.Equal(0, location.X);

            Assert.Equal(1, location.Y);

            Assert.Equal('N', location.Direction);
        }

        [Fact]
        public void Rover_can_go_in_circle()
        {
            // arrange
            var rover = new Rover(new Location(1, 1, 'N'));

            // action
            var location = rover.Move("LMLMLMLM");

            // assert
            Assert.NotNull(location);

            Assert.Equal(1, location.X);

            Assert.Equal(1, location.Y);

            Assert.Equal('N', location.Direction);
        }



    }
}
