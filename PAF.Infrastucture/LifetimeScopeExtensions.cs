using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac.Events;

// ReSharper disable once CheckNamespace
namespace Autofac
{
    public static class LifetimeScopeExtensions
    {
        public static async Task PublishEventAsync(this ILifetimeScope scope, object @event)
        {
            var exceptions = new List<Exception>();

            foreach (dynamic asyncHandler in scope.ResolveAsyncHandlers(@event))
            {
                try
                {
                    await asyncHandler.HandleAsync((dynamic)@event);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                }
            }
            if (exceptions.Count > 0)
                throw new AggregateException(exceptions);
        }

        public static IEnumerable<dynamic> ResolveAsyncHandlers<TEvent>(this ILifetimeScope scope, TEvent @event)
        {
            var eventType = @event.GetType();
            return scope.ResolveConcreteHandlers(eventType, MakeHandlerType);
        }

        private static IEnumerable<dynamic> ResolveConcreteHandlers(this ILifetimeScope scope, Type eventType, Func<Type, Type> handlerFactory)
        {
            return (IEnumerable<dynamic>)scope.Resolve(handlerFactory(eventType));
        }

        private static Type MakeHandlerType(Type type)
        {
            return typeof(IEnumerable<>).MakeGenericType(typeof(IHandleEventAsync<>).MakeGenericType(type));
        }
    }
}