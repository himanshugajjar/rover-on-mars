namespace RoversOnMars
{
    public class Rover : MarsRobot, IRobot
    {
        public Location CurrentLocation { get; private set; }

        public int Id { get; set; }

        public Rover()
        {
            CurrentLocation = new Location(0, 0, 'N');
        }

        public Rover(Location location)
        {
            CurrentLocation = location;
        }

        public Location Move(string moveCommand)
        {
            var location = new Location(CurrentLocation);

            moveCommand = moveCommand.ToUpper();

            foreach (var command in moveCommand)
            {
                if (command == 'L')
                {
                    // turn 90 deg left
                    location.Direction = TurnLeft(location.Direction);
                }
                else if (command == 'R')
                {
                    // turn 90 deg right
                    location.Direction = TurnRight(location.Direction);
                }
                else if (command == 'M')
                {
                    // Move forward
                    MoveForward(location);
                }
            }

            CurrentLocation = location;

            return location;
        }
    }
}