using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhdanov_hw7
{
    ///<summary>
    ///Машина состояний для юнитов
    ///</summary>
    ///<typeram name = "Tstate"></typeram>
    internal class UnitStateManager<TState> where TState : struct, Enum
    {
        ///<summary>
        ///Текущее состояние
        ///</summary>
        public TState Current { get; set; }

        private readonly TState[] _enumValues;
        private readonly bool[,] _states;

        public UnitStateManager() 
        {
            _enumValues = Enum.GetValues<TState>();
            _states = new bool[_enumValues.Length, _enumValues.Length];
            Current = default;
        }
        /// <summary>
        /// Переходы между состояниями
        /// </summary>
        /// <param name = "fromState">Исходное состояние</param>
        /// <param name = "to">Последующее состояние</param>
        /// <param name = "fromState">Исходное состояние</param>
        public void Transition(TState from, TState to) 
        {
            var fromIndex = Array.IndexOf(_enumValues, from);
            var toIndex = Array.IndexOf(_enumValues, to);

            _states[fromIndex, toIndex] = true;
        }
        ///<summary>
        ///Осуществление переходов между состояниями
        ///</summary>
        ///<param name = "state">Конечное состояние</param>
        public void Moveto(TState toState)
        {
            var fromIndex = Array.IndexOf(_enumValues, Current);
            var toIndex = Array.IndexOf(_enumValues, toState);

            if (!_states[fromIndex, toIndex])
            {
                throw new Exception($"Transition is imposible");
            }
            Current = toState;
        }
    }

}

