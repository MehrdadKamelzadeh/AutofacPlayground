using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Autofac.Events;

namespace PlaygroundAutofac
{
    public class OrderReviewRemoveHandler : IHandleEventAsync<OrderDeletedEventArgs>
    {
        public Task HandleAsync(OrderDeletedEventArgs @event)
        {
            throw new NotImplementedException();
        }
    }
}