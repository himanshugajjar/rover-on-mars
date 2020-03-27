using System;
using System.Collections.Generic;

namespace RoversOnMars
{
    public class Mars
    {
        private readonly IPlateau _plateau;

        private readonly IEnumerable<IRobot> _robots;

        public Mars(IPlateau plateau, IEnumerable<IRobot> robots)
        {
            _plateau = plateau;
            _robots = robots;
        }
    }
}
