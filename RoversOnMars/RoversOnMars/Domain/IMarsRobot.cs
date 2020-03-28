using RoversOnMars.Enums;
using RoversOnMars.Models;

namespace RoversOnMars.Domain
{
    public interface IMarsRobot
    {
        Orientation TurnLeft(Orientation orientation);

        Orientation TurnRight(Orientation orientation);

        Location MoveForward(Location lastLocaiton);
    }
}