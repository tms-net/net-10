using System;
using System.ComponentModel;
using System.Reflection;

namespace Homework7
{
    internal static class Program
    {
        private static readonly UnitStateManager<FighterState> _fighterStateManager = new(FighterState.Awaiting);
        private static readonly UnitStateManager<PlaneState> _planeStateManager = new(PlaneState.TakeOff);
        private static readonly UnitStateManager<CanonState> _canonStateManager = new(CanonState.Awaiting);

        static void Main(string[] args)
        {
            // Add allowed states
            _canonStateManager.AddAllowedStateTransition
            (
                (CanonState.Awaiting, CanonState.Aim),
                (CanonState.Aim, CanonState.Attack),
                (CanonState.Attack, CanonState.Awaiting)
            );
            _planeStateManager.AddAllowedStateTransition
            (
                (PlaneState.TakeOff, PlaneState.Attack),
                (PlaneState.Attack, PlaneState.Land),
                (PlaneState.Land, PlaneState.TakeOff)
            );
            _fighterStateManager.AddAllowedStateTransition
            (
                (FighterState.Awaiting, FighterState.Moving),
                (FighterState.Moving, FighterState.Attack),
                (FighterState.Attack, FighterState.Awaiting),
                (FighterState.Attack, FighterState.Protect),
                (FighterState.Protect, FighterState.Awaiting)
            );

            // Change states to the next stage
            _fighterStateManager.MoveToState(FighterState.Awaiting);
            _planeStateManager.MoveToState(PlaneState.TakeOff);
            _canonStateManager.MoveToState(CanonState.Awaiting);
            WriteStates();

            // Change states to the next stage
            _fighterStateManager.MoveToState(FighterState.Moving);
            _planeStateManager.MoveToState(PlaneState.Attack);
            _canonStateManager.MoveToState(CanonState.Aim);
            WriteStates();

            // Change states to the next stage
            _fighterStateManager.MoveToState(FighterState.Attack);
            _planeStateManager.MoveToState(PlaneState.Land);
            _canonStateManager.MoveToState(CanonState.Attack);
            WriteStates();

            // Change states to the next stage
            _fighterStateManager.MoveToState(FighterState.Protect);
            _planeStateManager.MoveToState(PlaneState.Land);
            _canonStateManager.MoveToState(CanonState.Attack);
            WriteStates();

        }

        private static void WriteStates()
        {
            Console.WriteLine("Current states of units:");
            Console.WriteLine($"Fighter state: {_fighterStateManager.CurrentState.GetDescription()}");
            Console.WriteLine($"Fighter state: {_planeStateManager.CurrentState.GetDescription()}");
            Console.WriteLine($"Fighter state: {_canonStateManager.CurrentState.GetDescription()}");
        }

        public static string GetDescription<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return source.ToString();
        }
    }
}