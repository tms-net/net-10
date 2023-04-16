using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWithOOP
{
    internal abstract class Vehicle : IMovable
    {
        private readonly int _year; 
        protected int CurrentSpeed;

        protected Vehicle(int year)
        {
            Year = year;
            // _year  = year;
        }

        internal string Make { get; set; } // Производитель
        internal string Model { get; set; } // Модель
        internal int Year { get; } // Год выпуска

        abstract internal void Start();
        virtual internal void Stop()
        {
            CurrentSpeed = 0;
        }
    }
}
