using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyContainer
{
    public class Dependency
    {
        public Dependency(Type type, DependencyLifeTime lifeTime)
        {
            this.Type = type;
            this.lifeTime = lifeTime;
        }
        public Type Type { get; set; }
        public DependencyLifeTime lifeTime { get; set; }
        public object Implementation { get; set; }
        public bool IsImplemented { get; set; }

        public void AddImplementation(object obj)
        {
            Implementation = obj;
            IsImplemented = true;
        }
    }

    public enum DependencyLifeTime
    {
        Singleton,
        Transient
    }
}
