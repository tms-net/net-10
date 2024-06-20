using System.ComponentModel;

namespace Homework7
{
    public enum FighterState
    {
        [Description("Awaiting")]
        Awaiting,

        [Description("Moving")]
        Moving,

        [Description("Attack")]
        Attack,

        [Description("Protect")]
        Protect
    }
}
