namespace StarDefence
{
    public class Static
    {
        static Pair<string> Pair { get; set; } = new Pair<string>();
    }

    public class Pair<TState>
    {
        public TState First { get; set; }
        public TState Second { get; set; }
    }

    //public class Tuple<TState>
    //{
    //    public TState From { get; set; }
    //    public TState To { get; set; }
    //}

    /// <summary>
    /// Автомат (машина) состояний для юнитов
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    public class UnitStateManager<TState> where TState: struct /* class */, Enum
    {
        private readonly Dictionary<TState, List<TState>> _dictionary;

        // TODO: Оптимизируйте алгоритм и структуры данных (Flags)

        private readonly TState[] _enumValues;
        private readonly bool[,] _transitionMatrix;
        private readonly (TState from, TState to)[] _states;

        // (x, y, z) != (y, x, z)

        public UnitStateManager(
            params (TState from, TState to)[] states) // ValueTuple
        {

            // валидация

            //states[0].Length == 2;
            //states[1].Length == 2;
            //states[2].Length == 2;

            // states[0].from;
            // states[0].to;

            //var from = states[0].Item1;
            //var to = states[0].Item2;

            // var t = new Tuple<TState, TState, TState, TState, TState>();

            #region Stack
            var stack = new Stack<string>(); // IEnumerable

            // Stack -> FILO
            // Add -> Push
            // Add -> Push

            // Get -> Peek
            // Get&Remove -> Pop

            // [
            //  [1] <- HEAD
            //  [0]
            // ]

            // Pop

            // [
            //  [0] <- HEAD
            // ]
            #endregion

            #region Queue
            // Queue -> FIFO
            // Add -> Enqueue
            // Add -> Enqueue

            // Get -> Peek
            // Get&Remove -> Dequeue

            // [ [2] [1] [0] ]
            //    ^       ^
            //    | TAIL  | HEAD

            // Dequeue

            //    [ [2] [1] ]
            //       ^   ^
            // TAIL  |   | HEAD

            // List: Enqueue == Add // [0, 1, 2]
            //       Dequeue == [0] + Remove(0) // 

            var queue = new Queue<string>(); // IEnumerable

            // реализовать стек с помощью массива

            // реализовать очередь с помощью 2-х стеков

            // queue.Peek();
            #endregion

            #region Collections
            // List -> Bag
            // Distionary -> Map -> Hashtable
            // HashSet -> HashTable

            // GetHashCode() -> int -> no collision
            // Equals()
            #endregion

            // [
            //  0 [Wait] ->  [Aim, Aim, Aim]
            //  1 [Aim] ->   [[Wait], [Atack]] -> [ 0    1      1    0 ] -> int == 4 byte -> [1 0 0 0]
            //                                     Aim  Wait  Atack
            //  2 [Atack] -> null
            // ]

            //[
            // [Wait] -> [Aim]
            //]

            _enumValues = Enum.GetValues<TState>();
            _transitionMatrix = new bool[_enumValues.Length, _enumValues.Length];

            var dictionary = new Dictionary<TState, HashSet<TState>>();

            var bitDict = new Dictionary<TState, TState>();

            for (int i = 0; i < states.Length; i++)
            {
                var transition = states[i];

                #region State Transition Matrix
                var fromIndex = Array.IndexOf(_enumValues, transition.from);
                var toIndex = Array.IndexOf(_enumValues, transition.from);

                _transitionMatrix[fromIndex, toIndex] = true;
                #endregion

                #region State Transition Dictionary of List/Hashset

                if (!dictionary.ContainsKey(transition.from))
                {
                    dictionary.Add(transition.from, new HashSet<TState> { transition.to });
                }
                else
                {
                    // [[Wait], [Atack], [Aim]] ~ O(N) для List, ~ O(1) для HashSet
                    // 
                    // кол-во операций для выполнения задачи

                    //if (!dictionary[transition.from].Contains(transition.to))
                    {
                        dictionary[transition.from].Add(transition.to);
                    }
                }
                #endregion

                #region State Transition Dictionary of BitMap

                if (!bitDict.ContainsKey(transition.from))
                {
                    bitDict.Add(transition.from, transition.to);
                }
                else
                {
                    bitDict[transition.from] = (bitDict[transition.from] | transition.to);
                    // 0 0 1 1
                    // 0 0 0 1
                }
                #endregion                
            }

            // ICollection<>
            // IEnumerable<>

            Current = default;
            _states = states;
        }

        /// <summary>
        /// Настройка переходов между состояниями
        /// </summary>
        /// <param name="fromState">Исходное состояние</param>
        /// <param name="toState">Последующее состояние</param>
        //public void AllowTransition(TState fromState, TState toState)
        //{
        //    // TODO: Выполните возможную валидацию параметров

        //    var fromIndex = Array.IndexOf(_enumValues, fromState);
        //    var toIndex = Array.IndexOf(_enumValues, toState);

        //    _states[fromIndex, toIndex] = true;
        //}

        /// <summary>
        /// Осуществить переход в состояние
        /// </summary>
        /// <param name="state">Конечное состояние</param>
        public void MoveTo(TState toState)
        {
            // TODO: Подумайте над крайними случаями значений (edge cases) (to same state)

            var fromIndex = Array.IndexOf(_enumValues, Current);
            var toIndex = Array.IndexOf(_enumValues, toState);

            //if (!_states[fromIndex,toIndex])
            //if (Array.IndexOf(_states, (Current, toState)) < 0)
            //if (_dictionary.TryGetValue(Current, out var toStates) &&
            //    !toStates.Contains(toState)) // O(N) -> O(1)
            if (_dictionary.TryGetValue(Current, out var toStates) &&
                (toStates & toState) == toStates)
            {
                throw new InvalidOperationException($"Transition not allowed from {Current} to {toState} state.");
            }

            // 0 0 1 1
            // 0 0 1 0
            //   AND
            // 0 0 1 0 == 0 0 1 0

            // 0 0 1 1
            // 0 1 0 0
            //   AND
            // 0 0 0 0 != 0 1 0 0

            // 0 0 1 1
            // 0 0 1 1
            //   AND
            // 0 0 1 1 == 0 0 1 1

            Current = toState;
        }

        /// <summary>
        /// Текущее состояние
        /// </summary>
        public TState Current { get; private set; }
    }
}
