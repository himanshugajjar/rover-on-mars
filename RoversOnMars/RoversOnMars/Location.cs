namespace RoversOnMars
{
    public class Location
    {
        public int X { get; set; }

        public int Y { get; set; }

        public char Direction { get; set; }

        private Location()
        { 
        }

        public Location (Location location)
        {
            X = location.X;

            Y = location.Y;

            Direction = location.Direction;
        }

        public Location(int x, int y, char direction)
        {
            X = x;
            
            Y = y;

            Direction = direction;
        }
    }
}