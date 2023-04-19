using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWithOOP.Vehicles
{
    internal abstract class Vehicle : IMovable
    {
        protected double CurrentSpeed = 0;
        protected double CoefficientOfFriction = 0.8;
        //protected double _coefficientOfFriction;

        protected Vehicle(string make, string model, int year, double weigh)
        {
            Make = make;
            Model = model;
            Year = year;
            Weight = weigh;
        }

        public string Make { get; } // Производитель
        public string Model { get; set; } // Модель
        public int Year { get; } // Год выпуска
        public double Weight { get; set; } // Вес
        /*
        public double CoefficientOfFriction
        { 
            get { return _coefficientOfFriction; } 
            set 
            {
                if (value > 0)
                { 
                    _coefficientOfFriction = value;
                }
            } 
        }//*/

        internal bool SetCoefficientOfFriction(double coefficient)
        {
            if (coefficient > 0)
            {
                CoefficientOfFriction = coefficient;
                return true;
            }
            else
                return false;               
        }//*/

        internal bool SuccessfulStopOnDistance(double distance)
        {
            if (Math.Pow(this.CurrentSpeed, 2) / (250 * this.CoefficientOfFriction) < distance)
            {
                this.Stop();
                return true;
            }   
            else
                return false;
        }

        virtual public double GetCurrentSpeed()
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
