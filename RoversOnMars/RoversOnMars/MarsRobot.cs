using System;

namespace RoversOnMars
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

            switch(lastLocation.Orientation)
            {
                case 'N':
                    newLocation.Y += 1;
                    break;
                case 'E':
                    newLocation.X += 1;
                    break;
                case 'S':
                    newLocation.Y -= 1;
                    break;
                case 'W':
                    newLocation.X -= 1;
                    break;
            };

            if (!_plateau.IsLocationOnPlateau(newLocation.X, newLocation.Y))
            {
                throw new InvalidOperationException($"Invalid Move : {nameof(Location.Orientation)} : {lastLocation.Orientation} ({newLocation.X}, {newLocation.Y})");
            }

            return newLocation;
        }

        public char TurnLeft(char orientation)
        {
            return orientation switch
            {
                'N' => 'W',
                'W' => 'S',
                'S' => 'E',
                'E' => 'N',
                _ => throw new InvalidOperationException($"Invalid Orientation : {orientation}"),
            };
        }

        public char TurnRight(char orientation)
        {
            return orientation switch
            {
                'N' => 'E',
                'E' => 'S',
                'S' => 'W',
                'W' => 'N',
                _ => throw new InvalidOperationException($"Invalid Orientation : {orientation}"),
            };
        }
    }
}