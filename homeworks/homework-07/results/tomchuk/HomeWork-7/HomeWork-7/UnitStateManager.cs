using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7
{
    internal class UnitStateManager<TState> where TState : struct, Enum
    {
        private readonly TState[] _enumValues;
        private readonly bool[,] _states;

        public UnitStateManager()
        {
            _enumValues = Enum.GetValues<TState>();
            _states = new bool[_enumValues.Length, _enumValues.Length];
            Current = default;
        }

        /// <summary>
        /// Настройка переходов между состояниями
        /// </summary>
        /// <param name="from">Исходное состояние</param>
        /// <param name="to">Последующее состояние</param>
        public void AllowTransition(TState from, TState to)
        {
            // получаем индексы
            var fromIndex = Array.IndexOf(_enumValues, from);
            var toIndex = Array.IndexOf(_enumValues, to);

            // разрешаем переход
            _states[fromIndex, toIndex] = true;
        }

        /// <summary>
        /// Осуществить переход в состояние
        /// </summary>
        /// <param name="state">Конечное состояние</param>
        public void MoveTo(TState toState)
        {
            var fromIndex = Array.IndexOf(_enumValues, Current);
            var toIndex = Array.IndexOf(_enumValues, toState);

            if (fromIndex < 0)
            {
                throw new ArgumentException(nameof(fromIndex));
            }

            if (toIndex < 0)
            {
                throw new ArgumentException(nameof(toIndex));
            }

            if (!_states[fromIndex, toIndex])
            {
                // запрещаем переход
                throw new InvalidOperationException($"Transition not allowed from {Current} to {toState} state.");
            }

            // осуществляем переход
            Current = toState;
        }

        /// <summary>
        /// Текущее состояние
        /// </summary>
        public TState Current { get; private set; }
    }
}
