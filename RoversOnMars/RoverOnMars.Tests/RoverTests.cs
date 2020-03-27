using Xunit;

namespace RoversOnMars.Tests
{
    public class RoverTests
    {
        private IPlateau _plateau;

        public RoverTests()
        {
            _plateau = new Plateau(100, 100);
        }

        [Fact]
        public void RoverMustHaveDefault_Location_0_0()
        {
            // arrange
            var rover = new Rover(_plateau);

            // action
            var location = rover.CurrentLocation;

            // assert
            Assert.NotNull(location);

            Assert.Equal(0, location.X);

            Assert.Equal(0, location.Y);

            Assert.Equal('N', location.Orientation);
        }

        [Fact]
        public void Rover_can_turn_left()
        {
            // arrange
            var rover = new Rover(_plateau);

            // action
            var location = rover.Move("L");

            // assert
            Assert.NotNull(location);

            Assert.Equal(0, location.X);

            Assert.Equal(0, location.Y);

            Assert.Equal('W', location.Orientation);
        }

        [Fact]
        public void Rover_can_turn_right()
        {
            // arrange
            var rover = new Rover(_plateau);

            // action
            var location = rover.Move("R");

            // assert
            Assert.NotNull(location);

            Assert.Equal(0, location.X);

            Assert.Equal(0, location.Y);

            Assert.Equal('E', location.Orientation);
        }

        [Fact]
        public void Rover_can_move_forward()
        {
            // arrange
            var rover = new Rover(_plateau);

            // action
            var location = rover.Move("M");

            // assert
            Assert.NotNull(location);

            Assert.Equal(0, location.X);

            Assert.Equal(1, location.Y);

            Assert.Equal('N', location.Orientation);
        }

        [Fact]
        public void Rover_can_go_in_circle()
        {
            // arrange
            var rover = new Rover(new Location(1, 1, 'N'), _plateau);

            // action
            var location = rover.Move("LMLMLMLM");

            // assert
            Assert.NotNull(location);

            Assert.Equal(1, location.X);

            Assert.Equal(1, location.Y);

            Assert.Equal('N', location.Orientation);
        }

        [Fact]
        public void Rover_can_go_in_up()
        {
            // arrange
            var rover = new Rover(new Location(1, 1, 'W'), _plateau);

            // action
            var location = rover.Move("RMM");

            // assert
            Assert.NotNull(location);

            Assert.Equal(1, location.X);

            Assert.Equal(3, location.Y);

            Assert.Equal('N', location.Orientation);
        }

        [Fact]
        public void Rover_can_go_in_down()
        {
            // arrange
            var rover = new Rover(new Location(2, 2, 'N'), _plateau);

            // action
            var location = rover.Move("LLMM");

            // assert
            Assert.NotNull(location);

            Assert.Equal(2, location.X);

            Assert.Equal(0, location.Y);

            Assert.Equal('S', location.Orientation);
        }

        [Fact]
        public void Rover_can_go_left_forward()
        {
            // arrange
            var rover = new Rover(new Location(2, 2, 'N'), _plateau);

            // action
            var location = rover.Move("LMM");

            // assert
            Assert.NotNull(location);

            Assert.Equal(0, location.X);

            Assert.Equal(2, location.Y);

            Assert.Equal('W', location.Orientation);
        }

        [Fact]
        public void Rover_can_go_right_forward()
        {
            // arrange
            var rover = new Rover(new Location(2, 2, 'N'), _plateau);

            // action
            var location = rover.Move("RMM");

            // assert
            Assert.NotNull(location);

            Assert.Equal(4, location.X);

            Assert.Equal(2, location.Y);

            Assert.Equal('E', location.Orientation);
        }

        [Fact]
        public void Rover_can_not_go_outside()
        {
            // arrange
            var rover = new Rover(new Location(2, 2, 'N'), _plateau);

            // action
            var location = rover.Move("LLMMM");

            // assert
            Assert.NotNull(location);

            Assert.Equal(2, location.X);

            Assert.Equal(0, location.Y);

            Assert.Equal('S', location.Orientation);
        }

    }
}
