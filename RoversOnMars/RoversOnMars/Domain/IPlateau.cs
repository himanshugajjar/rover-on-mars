namespace RoversOnMars.Domain
{
    public interface IPlateau
    {
        public int MinX { get; }
        public int MinY { get; }

        bool IsLocationOnPlateau(int x, int y);
    }
}