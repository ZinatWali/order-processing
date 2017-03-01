using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderSystem.Messaging
{
    public class Bus
    {
        private readonly Dictionary<Type, List<Action<object>>>  registry = new Dictionary<Type, List<Action<object>>>();

        public void Register<T>(Action<T> handler)
        {
            var t = typeof(T);

            if (!registry.ContainsKey(t))
            {
                registry[t] = new List<Action<object>>();
            }

            registry[t].Add(x => handler((T)x));
        }

        public void Publish<T>(T @event)
        {
            foreach (var handler in registry[typeof(T)])
            {
                handler(@event);
            }
        }

        public void Execute<T>(T command)
        {
            registry[typeof(T)].Single()(command);
        }
    }

    
}