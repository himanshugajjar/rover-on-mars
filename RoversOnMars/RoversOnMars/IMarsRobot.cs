namespace RoversOnMars
{
    public interface IMarsRobot
    {
        char TurnLeft(char currentDirection);

        char TurnRight(char currentDirection);

        void MoveForward(Location currentLocaiton);
    }
}