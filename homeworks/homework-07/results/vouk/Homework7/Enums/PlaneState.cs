using System.ComponentModel;

namespace Homework7
{
    public enum PlaneState
    {
        [Description("TakeOff")]
        TakeOff,

        [Description("Attack")]
        Attack,

        [Description("Land")]
        Land
    }
}
