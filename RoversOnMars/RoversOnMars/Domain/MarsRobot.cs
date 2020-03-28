using RoversOnMars.Enums;
using RoversOnMars.Models;
using System;

namespace RoversOnMars.Domain
{
    public class MarsRobot : IMarsRobot
    {
        private readonly IPlateau _plateau;

        public MarsRobot(IPlateau plateau)
        {
            _plateau = plateau;
        }

        public Location MoveForward(Location lastLocation)
        {
            var newLocation = new Location(lastLocation);

            switch (lastLocation.Orientation)
            {
                case Orientation.N:
                    newLocation.Y += 1;
                    break;
                case Orientation.E:
                    newLocation.X += 1;
                    break;
                case Orientation.S:
                    newLocation.Y -= 1;
                    break;
                case Orientation.W:
                    newLocation.X -= 1;
                    break;
            };

            if (!_plateau.IsLocationOnPlateau(newLocation.X, newLocation.Y))
            {
                throw new InvalidOperationException($"Invalid Move : {nameof(Location.Orientation)} : {lastLocation.Orientation} ({newLocation.X}, {newLocation.Y})");
            }

            return newLocation;
        }

        public Orientation TurnLeft(Orientation orientation)
        {
            return orientation switch
            {
                Orientation.N => Orientation.W,
                Orientation.W => Orientation.S,
                Orientation.S => Orientation.E,
                Orientation.E => Orientation.N,
                _ => throw new InvalidOperationException($"Invalid Orientation : {orientation}"),
            };
        }

        public Orientation TurnRight(Orientation orientation)
        {
            return orientation switch
            {
                Orientation.N => Orientation.E,
                Orientation.E => Orientation.S,
                Orientation.S => Orientation.W,
                Orientation.W => Orientation.N,
                _ => throw new InvalidOperationException($"Invalid Orientation : {orientation}"),
            };
        }
    }
}