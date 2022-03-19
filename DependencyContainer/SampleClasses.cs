using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyContainer
{
    public interface ICar
    {
        void Start();
    }

    public interface IEngine
    {
        void Start();
    }

    public interface IFuel
    {
        public void Fill();
    }

    public class Fuel : IFuel
    {
        public void Fill()
        {
            Console.WriteLine("Filling fuel");
        }
    }

    public class Engine : IEngine
    {
        private IFuel _fuel;
        public Engine(IFuel fuel)
        {
            _fuel = fuel;
        }

        public void Start()
        {
            Console.WriteLine("Engine started");
            _fuel.Fill();
        }
    }

    public class Car : ICar
    {
        private IEngine _engine;
        public Car(IEngine engine)
        {
            _engine = engine;
        }

        public void Start()
        {
            Console.WriteLine("Starting the car");
            _engine.Start();
        }
    }
}
