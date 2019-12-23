using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Events
{
    public class EventPublisher : IAsyncEventPublisher
    {
        public EventPublisher(ILifetimeScope scope)
        {
            _scope = scope;
        }

        private readonly ILifetimeScope _scope;

        public Task PublishAsync(object @event)
        {
            return _scope.PublishEventAsync(@event);
        }
    }
}