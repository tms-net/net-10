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
        protected double CurrentSpeed;

        protected Vehicle(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;           
            // _year  = year;
        }

        public string Make { get; set; } // Производитель
        public string Model { get; set; } // Модель
        public int Year { get; } // Год выпуска

        virtual public double CheckCurrentSpeed()
        {
            return CurrentSpeed;
        }

        abstract public void Start();
        virtual public void Stop()
        {
            CurrentSpeed = 0;
        }
    }
}
