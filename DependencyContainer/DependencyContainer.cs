using System;
using System.Collections.Generic;

namespace DependencyContainer
{
    public class DependencyContainer
    {
        Dictionary<Type, Dependency> _dependencies;

        public DependencyContainer()
        {
            _dependencies = new Dictionary<Type, Dependency>();
        }

        public void AddSingleton<KeyType, InstanceType>() {
            _addDependency<KeyType>(new Dependency(typeof(InstanceType), DependencyLifeTime.Singleton));
        }

        public void AddTransient<KeyType, InstanceType>()
        {
            _addDependency<KeyType>(new Dependency(typeof(InstanceType), DependencyLifeTime.Transient));
        }

        private void _addDependency<KeyType>(Dependency dependency) {
            _dependencies.Add(typeof(KeyType), dependency);
        }

        public Dependency GetDependency(Type type)
        {
            try
            {
                return _dependencies[type];
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("No dependency added for key " + type.ToString());
            }
        }
    }
}
