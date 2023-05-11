using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        private readonly Dictionary<TState, List<TState>> _states;

        public UnitStateManager()
        {
            // TODO: Используйте конструктор для определения переходов между состояниями

            _enumValues = Enum.GetValues<TState>();

            _states = new Dictionary<TState, List<TState>>();            
            
            Current = default;
        }

        /// <summary>
        /// Настройка переходов между состояниями
        /// </summary>
        /// <param name="fromState">Исходное состояние</param>
        /// <param name="toState">Последующее состояние</param>
        public void AllowTransition(TState fromState, TState toState)
        {
            if (Array.IndexOf(_enumValues, fromState) == -1)
            {
                throw new ArgumentException("Try to add unavailable State");
            }
            // получаем индексы
            bool finded = false;
            // разрешаем переход
            foreach (TState state in _states.Keys)
            {
                if (state.Equals(fromState))
                {
                    finded = true;
                    break;
                }                
            }
            if (!finded)
            {
                _states.Add(fromState, new List<TState>());
            }
            _states[fromState].Add(toState);
        }

        /// <summary>
        /// Осуществить переход в состояние
        /// </summary>
        /// <param name="toState">Конечное состояние</param>
        public void MoveTo(TState toState)
        {
            // TODO: Подумайте над крайними случаями значений (edge cases)
            bool finded = false;
            //var fromIndex = Array.IndexOf(_enumValues, Current);
            //var toIndex = Array.IndexOf(_enumValues, toState);
            foreach (TState state in _states.Keys)
            {
                if (_states[Current].IndexOf(toState) == -1)
                {
                    // запрещаем переход
                    throw new InvalidOperationException($"Transition not allowed from {Current} to {toState} state.");
                }
                else
                {
                    // осуществляем переход
                    Current = toState;
                    finded = true;
                    break;
                }                
            }
            if(!finded) throw new IndexOutOfRangeException("Can't transite to unexist state.");                      
        }

        /// <summary>
        /// Текущее состояние
        /// </summary>
        public TState Current { get; private set; }
    }
}
