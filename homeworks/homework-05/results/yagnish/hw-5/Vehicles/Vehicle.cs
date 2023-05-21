using hw_5.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_5.Vehicles
{
    internal class Vehicle: IMovable, IHaveEngine
    {
        protected int _currentSpeed;

        protected bool isEngineOn;
        public string? Year { get; }
        public string? Model { get; }
        public string? Mark { get; }
        public string? MaxSpeed { get; }

        protected Vehicle( string year, string model, string mark, string maxSpeed)
        {
            _currentSpeed =0;
            Year = year;
            Mark = mark;
            Model = model;
            MaxSpeed = maxSpeed;
        }

        public override string ToString()
        {
            var stringValue =
                @$" Type: {GetType().Name}
                    Mark: {Mark}
                    Model: {Model}
                    Year of manufacture {Year}";

            return stringValue;
        }

        public void StartEngine()
        {
            isEngineOn = true;
        }
        public void StopEngine()
        {
            isEngineOn = false;
        }

        public void UpdateSpeed(int newSpeed)
        {
            if (newSpeed >= 0 && newSpeed <= Int32.Parse(MaxSpeed))
                _currentSpeed = newSpeed;
            else
                throw new Exception("Invali speed");    
        }

        public void StartMovement(int speed)
        {
            if (!isEngineOn)
                StartEngine();
            UpdateSpeed(speed);
        }

        public void StopMovement()
        {
            _currentSpeed = 0;
        }

        public void CheckState()
        {
            Console.WriteLine(@$"Name:{Model}
                                 Speed: {_currentSpeed}
                                 EngineOn: {isEngineOn}");
        }

    }
}
