using RoversOnMars.Models;
using System;

namespace RoversOnMars.Domain
{
    public interface IRobot
    {
        Location CurrentLocation { get; }

        Guid Id { get; }

        Location Move(string moveCommand);
    }
}