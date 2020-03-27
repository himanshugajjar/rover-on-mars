using System;

namespace RoversOnMars
{
    public interface IRobot
    {
        Location CurrentLocation { get; }

        Guid Id { get; }

        Location Move(string moveCommand);
    }
}