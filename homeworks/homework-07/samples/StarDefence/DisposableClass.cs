using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace StarDefence
{
    internal class DisposableClass : IDisposable
    {
        FileHandle filehandle;

        public DisposableClass()
        {
        }

        // finalizer
        ~DisposableClass() // деструктор :(
        {
            handle.Close();
        }
    }

    // -> FreachableQueue [ [DisposableClass] ]  ->
    // -> FinalizerQueue -> ~DisposableClass() -> GC

    // Generation 0, 1, 2
}
