using System;

namespace Homework_7
{
	public class UnitStateManager<TState> where TState: System.Enum
	{
        private Dictionary<TState, HashSet<TState>> _allowedStateTransitions = new Dictionary<TState, HashSet<TState>>();

        public TState CurrentState { get; private set; }

        public UnitStateManager(TState initialState)
        {
            CurrentState = initialState;
        }

        //add allowed state for transition using Tuples of from_state and to_state
        public void AddAllowedStateTransition(params (TState from, TState to)[] states)
		{
			for(int i = 0; i < states.Length; i++)
			{
                if (!_allowedStateTransitions.ContainsKey(states[i].from))
                {
                    _allowedStateTransitions.Add(states[i].from, new HashSet<TState>());
                }

				_allowedStateTransitions[states[i].from].Add(states[i].to); //add 'to' state into HashSet table
            }
        }

        public bool MoveToState(TState toState)
        {
            if (_allowedStateTransitions[CurrentState].Contains(toState))
            {
                CurrentState = toState;
                return true;
            }

            return false;
        }
	}
}

