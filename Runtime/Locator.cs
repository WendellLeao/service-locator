using System;
using System.Collections.Generic;

namespace WendellLeao.ServiceLocator
{
    public static class Locator
    {
        private static readonly Dictionary<Type, object> Services = new();

        public static void Register<T>(T service)
        {
            EnsureIsInterface<T>();

            Services[typeof(T)] = service;
        }

        public static void Unregister<T>()
        {
            EnsureIsInterface<T>();

            Services.Remove(typeof(T));
        }

        private static void EnsureIsInterface<T>()
        {
            if (!typeof(T).IsInterface)
            {
                throw new ArgumentException($"Locator only accepts interfaces, but {typeof(T)} is a concrete type.");
            }
        }

        public static T Get<T>()
        {
            EnsureIsInterface<T>();

            if (!Services.TryGetValue(typeof(T), out object service))
            {
                throw new InvalidOperationException($"Service {typeof(T)} not registered.");
            }

            return (T)service;
        }
    }
}
