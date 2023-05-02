namespace Homework7
{
    public class UnitStateManager<TState> where TState : Enum
    {
        private readonly Dictionary<TState, HashSet<TState>> _allowedStateTransitions = new();

        public TState CurrentState { get; private set; }

        public UnitStateManager(TState state)
        {
            CurrentState = state;
        }

        public void AddAllowedStateTransition(params (TState from, TState to)[] states)
        {
            for (var i = 0; i < states.Length; i++)
            {
                if (!_allowedStateTransitions.ContainsKey(states[i].from))
                {
                    _allowedStateTransitions.Add(states[i].from, new HashSet<TState>());
                }

                _allowedStateTransitions[states[i].from].Add(states[i].to);
            }
        }

        public bool MoveToState(TState toState)
        {
            if (!_allowedStateTransitions[CurrentState].Contains(toState))
            {
                return false;
            }

            CurrentState = toState;
            return true;

        }
    }
}
