using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_7
{
    public class UniteStateManager<T> where T : struct, Enum
    {
        private readonly Dictionary<T,T> bitDict = new Dictionary<T, T>();
        private readonly T[] _enumValues;
        public T _current { get; private set; }
        public UniteStateManager(Tuple<T, T>[] tuples)
        {
            _enumValues = Enum.GetValues<T>();
            _current = default;
            foreach (var tuple in tuples)
            {
                if (!bitDict.ContainsKey(tuple.Item1))
                {
                    bitDict.Add(tuple.Item1,tuple.Item2);
                }
                else
                {
                    //var index1 =(int)Math.Pow(2, Array.IndexOf(_enumValues, tuple.Item1));
                    //var index2 =(int) Math.Pow(2, Array.IndexOf(_enumValues, tuple.Item2));
                    bitDict[tuple.Item1] = bitDict[tuple.Item1] | bitDict[tuple.Item2]; 
                }
            }

        }
        public void MoveTo(T toState)
        {
            if ((bitDict[_current]&toState) == toState)
                 throw new InvalidOperationException($"Transition not allowed from {_current} to {toState} state.");
            _current = toState;
        }
    }
}
