namespace RoversOnMars
{
    public interface IMarsRobot
    {
        char TurnLeft(char currentOrientation);

        char TurnRight(char currentOrientation);

        Location MoveForward(Location currentLocaiton);
    }
}