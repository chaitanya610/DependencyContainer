using System;

namespace DependencyContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var dependencyContainer = new DependencyContainer();
            dependencyContainer.AddSingleton<ICar, Car>();
            dependencyContainer.AddSingleton<IEngine, Engine>();
            dependencyContainer.AddTransient<IFuel, Fuel>();

            var dependencyResolver = new DependencyResolver(dependencyContainer);

            try
            {
                var car = dependencyResolver.GetService<ICar>();
                car.Start();

                Console.WriteLine("\n\nTesting singleton instances");
                Console.WriteLine(car.GetHashCode());

                var car2 = dependencyResolver.GetService<ICar>();

                Console.WriteLine(car2.GetHashCode());


                var fuel1 = dependencyResolver.GetService<IFuel>();
                var fuel2 = dependencyResolver.GetService<IFuel>();

                Console.WriteLine("\n\nTesting transcient instances");
                Console.WriteLine(fuel1.GetHashCode());
                Console.WriteLine(fuel2.GetHashCode());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
