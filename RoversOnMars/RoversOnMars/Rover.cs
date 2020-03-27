namespace RoversOnMars
{
    public class Rover : IMarsRobot
    {
        public Location CurrentLocation { get; private set; }

        public Rover()
        {
            CurrentLocation = new Location(0, 0, 'N');
        }

        public Location Move(string moveCommand)
        {
            return null;
        }
    }
}