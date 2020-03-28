namespace RoversOnMars
{
    public interface IMarsRobot
    {
        char TurnLeft(char orientation);

        char TurnRight(char orientation);

        Location MoveForward(Location lastLocaiton);
    }
}