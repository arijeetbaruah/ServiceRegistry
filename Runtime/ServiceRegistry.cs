using System;
using System.Collections.Generic;

namespace Core.Service
{
    public static class ServiceRegistry
    {
        public static Dictionary<Type, IService> registry = new Dictionary<Type, IService>();

        static ServiceRegistry()
        {
            registry = new Dictionary<Type, IService> ();
        }

        public static void AddToRegistry<T>(T service) where T : class, IService, new()
        {
            if (!registry.ContainsKey(service.GetType()))
            {
                registry.Add(typeof(T), service);
            }
        }

        public static T Get<T>() where T : class, IService, new()
        {
            if (registry.TryGetValue(typeof(T), out var service))
            {
                return (T)service;
            }

            return null;
        }

        public static void Remove<T>() where T : class, IService, new()
        {
            registry.Remove(typeof(T));
        }
    }
}
