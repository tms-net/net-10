using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Zanka_dz_7
{

    /// <summary>
    /// Cостояния остальных юнитов
    /// </summary>
    /// <typeparam name="Tstages"></typeparam>
    internal class MoveStages <Tstages> where Tstages : struct, Enum
    {
        private readonly Tstages[] _enumValues;
        public readonly bool[,] _stage;

        public MoveStages()
        {
            _enumValues = Enum.GetValues<Tstages>();
            _stage = new bool[_enumValues.Length, _enumValues.Length];
            Current = default;
        }
        /// <summary>
        /// Переход между состояниями
        /// </summary>
        public void Movements(Tstages from, Tstages to)
        {
            var fromindex = Array.IndexOf(_enumValues, from);
            var toindex = Array.IndexOf(_enumValues, to);
            _stage[fromindex, toindex] = true; 
        }
        /// <summary>
        /// Изменение состояния
        /// </summary>
        public void MoveTo(Tstages stage)
        {
            var fromindex = Array.IndexOf(_enumValues, Current);
            var toindex = Array.IndexOf(_enumValues, stage);

            if (!_stage[fromindex, toindex])
            {
                throw new InvalidOperationException($"Transition not allowed from {Current} to {stage} stage.");
            }
            Current = stage;
        }
        /// <summary>
        /// Текущее состоянме
        /// </summary>
        public Tstages Current { get; private set; }

        
    }
}
