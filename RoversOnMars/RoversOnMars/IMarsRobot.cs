namespace RoversOnMars
{
    public interface IMarsRobot
    {
        Location CurrentLocation { get; }

        Location Move(string moveCommand);
    }
}