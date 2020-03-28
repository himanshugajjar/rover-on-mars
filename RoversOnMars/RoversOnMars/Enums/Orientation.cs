using System.ComponentModel.DataAnnotations;

namespace RoversOnMars.Enums
{
    public enum Orientation
    {
        [Display(Name = "North")]
        N,
        [Display(Name = "East")]
        E,
        [Display(Name = "South")]
        S,
        [Display(Name = "West")]
        W
    }
}
