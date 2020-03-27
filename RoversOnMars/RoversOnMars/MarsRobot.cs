using System;

namespace RoversOnMars
{
    public class MarsRobot : IMarsRobot
    {
        public void MoveForward(Location locaiton)
        {
            switch(locaiton.Direction)
            {
                case 'N': locaiton.Y += 1;
                    break;
                case 'W': locaiton.X += 1;
                    break;
                case 'S': locaiton.Y -= 1;
                    break;
                case 'E': locaiton.X -= 1;
                    break;
            };
        }

        public char TurnLeft(char currentDirection)
        {
            return currentDirection switch
            {
                'N' => 'E',
                'E' => 'S',
                'S' => 'W',
                'W' => 'N',
                _ => currentDirection,
            };
        }

        public char TurnRight(char currentDirection)
        {
            return currentDirection switch
            {
                'N' => 'W',
                'W' => 'S',
                'S' => 'E',
                'E' => 'N',
                _ => currentDirection,
            };
        }
    }
}