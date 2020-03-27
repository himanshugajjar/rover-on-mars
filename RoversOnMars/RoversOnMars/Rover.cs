﻿using System;

namespace RoversOnMars
{
    public class Rover : MarsRobot, IRobot
    {
        private readonly IPlateau _plateau;

        public Location CurrentLocation { get; private set; }

        public int Id { get; set; }

        public Rover(IPlateau plateau) : base(plateau)
        {
            CurrentLocation = new Location(plateau.MinX, plateau.MinY, 'N');
        }

        public Rover(Location location, IPlateau plateau) : base(plateau)
        {
            CurrentLocation = location;

            _plateau = plateau;
        }

        public Location Move(string moveCommand)
        {
            var location = new Location(CurrentLocation);

            moveCommand = moveCommand.ToUpper();

            try
            {
                foreach (var command in moveCommand)
                {
                    if (command == 'L')
                    {
                        // turn 90 deg left
                        location.Orientation = TurnLeft(location.Orientation);
                    }
                    else if (command == 'R')
                    {
                        // turn 90 deg right
                        location.Orientation = TurnRight(location.Orientation);
                    }
                    else if (command == 'M')
                    {
                        // Move forward
                        location = MoveForward(location);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            CurrentLocation = location;

            return location;
        }
    }
}