using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star_Defence__ConsoleApp_
{
    /// <summary>
    /// Автомат (машина) состояний для юнитов
    /// </summary>
    /// <typeparam name="TState">Тип состояния</typeparam>
    internal class UnitStateManager<TState> where TState : struct, Enum
    {
        // TODO: Оптимизируйте алгоритм и структуры данных

        private readonly TState[] _enumValues;
        private readonly bool[,] _states;

        public UnitStateManager()
        {
            // TODO: Используйте конструктор для определения переходов между состояниями

            _enumValues = Enum.GetValues<TState>();
            _states = new bool[_enumValues.Length, _enumValues.Length];

            Current = default;
        }

        /// <summary>
        /// Настройка переходов между состояниями
        /// </summary>
        /// <param name="fromState">Исходное состояние</param>
        /// <param name="toState">Последующее состояние</param>
        public void AllowTransition(TState fromState, TState toState)
        {
            // получаем индексы
            var fromIndex = Array.IndexOf(_enumValues, fromState);
            var toIndex = Array.IndexOf(_enumValues, toState);

            // разрешаем переход
            _states[fromIndex, toIndex] = true;
        }

        /// <summary>
        /// Осуществить переход в состояние
        /// </summary>
        /// <param name="toState">Конечное состояние</param>
        public void MoveTo(TState toState)
        {
            // TODO: Подумайте над крайними случаями значений (edge cases)

            var fromIndex = Array.IndexOf(_enumValues, Current);
            var toIndex = Array.IndexOf(_enumValues, toState);

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
