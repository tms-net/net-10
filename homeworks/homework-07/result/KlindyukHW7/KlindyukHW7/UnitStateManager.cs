using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlindyukHW7
{
    /// <summary>
    /// Автомат (машина) состояний для юнитов
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    internal class UnitStateManager<TState> where TState : struct, Enum
    {

        /// <summary>
        /// Текущее состояние
        /// </summary>
        public TState Current { get; private set; }
        private Dictionary<TState, HashSet<TState>> _allowedStates = new Dictionary<TState, HashSet<TState>>();


        public UnitStateManager(TState current)
        {
            Current = current;
        }

        /// <summary>
        /// Настройка переходов между состояниями
        /// </summary>
        /// <param name="from">Исходное состояние</param>
        /// <param name="to">Последующее состояние</param>
        public void AllowTransition(params (TState from, TState to)[] states)
        {
            for (int i = 0; i < states.Length; i++)
            {
                if (!_allowedStates.ContainsKey(states[i].from))
                {
                    _allowedStates.Add(states[i].from, new HashSet<TState>());
                }
                _allowedStates[states[i].from].Add(states[i].to);
            }
        }

        /// <summary>
        /// Осуществлять переход в состояние
        /// </summary>
        /// <param name="toState">Конечное состояние</param>
        public bool MoveTo(TState toState)
        {
            if (_allowedStates[Current].Contains(toState))
            {
                Current = toState;
                return true;
            }
            return false;
        }
    }
}
