using System.Security;

namespace Patapau
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

        private readonly Dictionary<TState, HashSet<TState>> dictionary;

        public UnitStateManager(params (TState fromState, TState toState)[] states)
        {
            dictionary = new Dictionary<TState, HashSet<TState>>();

            foreach (var state in states)
            {
                if(!dictionary.ContainsKey(state.fromState))
                {
                    dictionary.Add(state.fromState, new HashSet<TState>(){state.toState});
                }
                else
                {
                    dictionary[state.fromState].Add(state.toState);
                }
            }
            Current = default;
        }


        /// <summary>
        /// Настройка переходов между состояниями (добавление разрешений)
        /// </summary>
        /// <param name="fromState">Исходное состояние</param>
        /// <param name="toState">Последующее состояние</param>
        public void AllowTransition(TState fromState, TState toState)
        {
            if (!dictionary.ContainsKey(fromState))
            {
                dictionary.Add(fromState, new HashSet<TState>() { toState });
            }
            else
            {
                dictionary[fromState].Add(toState);
            }
        }


        /// <summary>
        /// Настройка переходов между состояниями (удаление разрешений)
        /// </summary>
        /// <param name="fromState">Исходное состояние</param>
        /// <param name="toState">Последующее состояние</param>
        public void DeletePermissionTransition(TState fromState, TState toState)
        {
            if (dictionary.ContainsKey(fromState) && dictionary[fromState].Contains(toState))
            {
                if (dictionary[fromState].Count<2)
                {
                    dictionary.Remove(fromState);
                }
                else
                {
                    dictionary[fromState].Remove(toState);
                }
            }
            else
            {
                throw new InvalidOperationException($"Transition from state {Current} to state {toState} was not detected.");
            }
        }


        /// <summary>
        /// Осуществить переход в состояние
        /// </summary>
        /// <param name="toState">Конечное состояние</param>
        public void MoveTo(TState toState)
        {

            if (dictionary.ContainsKey(Current) && dictionary[Current].Contains(toState))
            {
                Current = toState;
            }
            else
            {
                throw new InvalidOperationException($"Transition not allowed from {Current} to {toState} state.");
            }

        }

    }

}

