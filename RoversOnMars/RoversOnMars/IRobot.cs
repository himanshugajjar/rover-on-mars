namespace RoversOnMars
{
    public interface IRobot
    {
        Location CurrentLocation { get; }

        int Id { get; set; }

        Location Move(string moveCommand);
    }
}