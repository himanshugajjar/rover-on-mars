using RoversOnMars.Models;
using System;
using System.Collections.Generic;

namespace RoversOnMars
{
    public interface IMars
    {
        Location MoveRobot(Guid robotId, string command);

        IEnumerable<Guid> DeployRovers(IEnumerable<Location> locations);
    }
}