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

        public Location MoveForward(Location location)
        {
            var newLocation = new Location(location);

            switch(location.Orientation)
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
                throw new InvalidOperationException($"Invalid Move : {nameof(Location.Orientation)} : {location.Orientation} ({newLocation.X}, {newLocation.Y})");
            }

            return newLocation;
        }

        public char TurnLeft(char currentOrientation)
        {
            return currentOrientation switch
            {
                'N' => 'W',
                'W' => 'S',
                'S' => 'E',
                'E' => 'N',
                _ => currentOrientation,
            };
        }

        public char TurnRight(char currentOrientation)
        {
            return currentOrientation switch
            {
                'N' => 'E',
                'E' => 'S',
                'S' => 'W',
                'W' => 'N',
                _ => currentOrientation,
            };
        }
    }
}