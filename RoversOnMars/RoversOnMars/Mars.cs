using System;
using System.Collections.Generic;
using System.Linq;

namespace RoversOnMars
{
    public class Mars : IMars
    {
        private readonly IPlateau _plateau;

        private IList<IRobot> _robots = new List<IRobot>();

        public Mars(IPlateau plateau)
        {
            _plateau = plateau;
        }

        public IEnumerable<Guid> DeployRovers(IEnumerable<Location> locations)
        {
            _robots = new List<IRobot>();

            foreach (var loc in locations)
            {
                if (_plateau.IsLocationOnPlateau(loc.X, loc.Y))
                {
                    _robots.Add(new Rover(loc, _plateau));
                }
                else
                {
                    throw new InvalidOperationException($"Unable to deploy this rover. Location is outside plateau range ({loc.X}, {loc.Y})");
                }
            }

            return _robots.Select(x => x.Id);
        }

        public Location MoveRobot(Guid robotId, string command)
        {
            var robot = _robots.FirstOrDefault(x => x.Id == robotId);

            if (robot != null)
            {
                return robot.Move(command);
            }
            else 
            {
                Console.WriteLine($"Error: Unable to find robot with Id : {robotId}");

                return null;
            }
        }
    }

}
