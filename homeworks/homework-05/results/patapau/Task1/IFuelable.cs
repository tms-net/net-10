﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patapau.Task1
{
    public interface IFuelable
    {
        void HalfTank();
        void FullTank();
        void GetFuelLevel();
    }
}
