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
        public async Task HandleAsync(OrderDeletedEventArgs @event)
        {
            var x = 2;
        }
    }
}