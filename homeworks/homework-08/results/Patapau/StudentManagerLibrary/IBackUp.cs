using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerLibrary
{
    public interface IBackUp
    {
        void BackUp();
        bool RollBack();
    }
}
