using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DependencyContainer
{
    public class DependencyResolver
    {
        private DependencyContainer _dependencyContainer;
        public DependencyResolver(DependencyContainer dependencyContainer)
        {
            _dependencyContainer = dependencyContainer;
        }
        public KeyType GetService<KeyType>()
        {
            return (KeyType)GetService(typeof(KeyType));   
        }

        public object GetService(Type type)
        {
            var dependency = _dependencyContainer.GetDependency(type);
            var constructor = dependency.Type.GetConstructors().First();
            var constructorParameters = constructor.GetParameters();

            if (constructorParameters.Length > 0)
            {
                var constructorParameterInstances = new List<object>();
                foreach (var parameter in constructorParameters)
                {
                    constructorParameterInstances.Add(GetService(parameter.ParameterType));
                }

                return _getInstance(dependency, (x) => Activator.CreateInstance(x, constructorParameterInstances.ToArray()));

            }

            return _getInstance(dependency, (x) => Activator.CreateInstance(x));
        }

        private object _getInstance(Dependency dependency, Func<Type, object> createInstance)
        {
            if (dependency.IsImplemented)
            {
                return dependency.Implementation;
            }

            var instance = createInstance(dependency.Type);

            if (dependency.lifeTime == DependencyLifeTime.Singleton)
            {
                dependency.AddImplementation(instance);
            }

            return instance;
        }
    }
}
