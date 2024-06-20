using System.ComponentModel;

namespace Homework7
{
    public enum CanonState
    {
        [Description("Awaiting")]
        Awaiting,

        [Description("Aim")]
        Aim,

        [Description("Attack")]
        Attack
    }
}