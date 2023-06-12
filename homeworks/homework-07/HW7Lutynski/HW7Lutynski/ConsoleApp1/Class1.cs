namespace HW7Lutynski
{

    internal class UnitStateManager<TState> where TState : struct, Enum
    {
        private readonly bool[,] _states;
        private readonly TState[] _enumValues;
        public TState Current { get; private set; }
        public UnitStateManager()
        {

            _enumValues = Enum.GetValues<TState>();
            _states = new bool[_enumValues.Length, _enumValues.Length];
            Current = default;
        }

        public void AllowTransition(TState fromState, TState toState)
        {
            var fromIndex = Array.IndexOf(_enumValues, fromState);
            var toIndex = Array.IndexOf(_enumValues, toState);
            _states[fromIndex, toIndex] = true;
        }
        public void MoveTo(TState toState)
        {


            if (!Enum.IsDefined(typeof(TState), toState))
            {
                throw new ArgumentOutOfRangeException(nameof(toState), "Значение не определено в перечислении.");
            }

            var fromIndex = Array.IndexOf(_enumValues, Current);
            var toIndex = Array.IndexOf(_enumValues, toState);
            if (_states[fromIndex, toIndex])
            {

                Current = toState;
                Console.WriteLine($"текущее состояние - {Current}");
                switch (Current)
                {
                    case TankState.Shoot:
                    case DestroyerState.Shoot:
                    case CanonState.Shoot:
                        HitChance();
                        break;
                }
            }
            else
            {
                throw new InvalidOperationException($"Невозможно выполнить переход из {Current} в {toState}");
            }

        }
        public void HitChance()
        {
            var Accuracy = new Random();
            if (Accuracy.Next(3) > 1) { Console.WriteLine("Попадание"); }
            else { Console.WriteLine("Промах!"); }

        }

    }
}