namespace RoversOnMars
{
    public class Location
    {
        public int X { get; set; }

        public int Y { get; set; }

        public char Orientation { get; set; }

        private Location()
        { 
        }

        public override string ToString()
        {
            return $"{X} {Y} {Orientation}";
        }

        public Location (Location location)
        {
            X = location.X;

            Y = location.Y;

            Orientation = location.Orientation;
        }

        public Location(int x, int y, char orientation)
        {
            X = x;
            
            Y = y;

            Orientation = orientation;
        }
    }
}