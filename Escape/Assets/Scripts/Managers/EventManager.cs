using System;
using System.Collections.Generic;
using Managers.Base;

namespace Managers
{
    public class EventManager : SingletonManagerBase<EventManager>
    {
        private static Dictionary<Type, Delegate> events = new Dictionary<Type, Delegate>();

        public static void Subscribe<T>(Action<T> callback)
        {
            if (events.TryGetValue(typeof(T), out var exisitng))
                events[typeof(T)] = Delegate.Combine(exisitng, callback);
            else
                events[typeof(T)] = callback;
        }

        public static void Unsubscribe<T>(Action<T> callback)
        {
            if (events.TryGetValue(typeof(T), out var exisitng))
            {
                var current = Delegate.Remove(exisitng, callback);

                if (current == null)
                    events.Remove(typeof(T));
                else
                    events[typeof(T)] = current;
            }
        }

        public static void Publish<T>(T eventData)
        {
            if (events.TryGetValue(typeof(T), out var del))
            {
                ((Action<T>)del)?.Invoke(eventData);
            }
        }
    }
}