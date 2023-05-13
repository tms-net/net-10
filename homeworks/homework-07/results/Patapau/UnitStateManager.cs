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
        /// Осуществить переход в состояние
        /// </summary>
        /// <param name="toState">Конечное состояние</param>
        public void MoveTo(TState toState)
        {
            if (toState.Equals(Current))
            {
                throw new InvalidOperationException($"The object is already in this state");
            }
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

