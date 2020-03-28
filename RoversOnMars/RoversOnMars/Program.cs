using RoversOnMars.Domain;
using RoversOnMars.Enums;
using RoversOnMars.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoversOnMars
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Mission Orbiter Mars!");

                // Collect input
                // Plateau upper-right coordinates
                // Rover location
                // Send move commands to rovers
                
                Console.WriteLine("Please enter upper-coordinates of plateau.");
                var coordinates = Console.ReadLine();

                var plateau = CreatePlateau(coordinates);

                var (loctions, directions) = CollectRoverDetail();

                var mars = new Mars(plateau);

                Console.WriteLine("Deploying Rovers on Mars...");
                var roverIds = mars.DeployRovers(loctions).ToList();

                Console.WriteLine("Sending directions to Rovers...");
                Console.WriteLine("Rovers' final locations...");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                for (var i = 0; i < roverIds.Count; i++)
                {
                    var lastLocation = mars.MoveRobot(roverIds[i], directions[i]);

                    Console.WriteLine($"{lastLocation.X} {lastLocation.Y} {lastLocation.Orientation}");

                    loctions[i] = lastLocation;
                }

                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                Console.WriteLine("Misson Orbiter Mars: Successfully Completed");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine("Failed to deploy rovers on Mars.");
                Console.WriteLine("Misson Orbiter Mars: Failed");
            }

        }

        private static (List<Location>, List<string>) CollectRoverDetail()
        {
            Console.WriteLine("Please enter rover locations and directions.");
            Console.WriteLine("Enter twice to deploy rover and send command for directions.");

            var roverLocations = new List<Location>();
            var roverDirections = new List<string>();

            while (true)
            {
                var location = Console.ReadLine();

                if (string.IsNullOrEmpty(location)) break;

                var roverLocation = CreateLocation(location);

                if (roverLocation != null)
                    roverLocations.Add(roverLocation);
                else
                    continue;

                var direction = Console.ReadLine();

                if (string.IsNullOrEmpty(direction)) break;

                roverDirections.Add(direction);
            }

            // just in case direction for last rover is empty
            roverDirections = roverDirections.Take(roverLocations.Count).ToList();

            return (roverLocations, roverDirections);
        }

        private static Location CreateLocation(string location)
        {
            try
            {
                var points = location.Split(' ');

                var x = Convert.ToInt32(points[0]);
                var y = Convert.ToInt32(points[1]);
                var orientation = (Orientation)Enum.Parse(typeof(Orientation), points[2].ToUpper());

                return new Location(x, y, orientation);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to parse rover location : {location}");
            }

            return null;
        }

        private static Plateau CreatePlateau(string coordinates)
        {
            try
            {
                var points = coordinates.Split(' ');

                var maxX = Convert.ToInt32(points[0]);
                var maxY = Convert.ToInt32(points[1]);

                return new Plateau(maxX, maxY);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");

                throw new ArgumentException(message: $"Failed to parse plateau upper-right coordinates : {coordinates}");
            }
        }
    }
}
