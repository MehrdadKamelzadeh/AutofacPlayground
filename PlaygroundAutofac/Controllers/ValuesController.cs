using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
using Autofac.Events;

namespace PlaygroundAutofac.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly ISomethingService _somethingService;
        private readonly IEventTypeStrategyFinder _eventTypeStrategyFinder;
        private readonly IComponentContext _componentContext;
        private readonly IAsyncEventPublisher _eventPublisher;

        public ValuesController(ISomethingService somethingService, IEventTypeStrategyFinder eventTypeStrategyFinder, IComponentContext componentContext, IAsyncEventPublisher eventPublisher)
        {
            _somethingService = somethingService;
            _eventTypeStrategyFinder = eventTypeStrategyFinder;
            _componentContext = componentContext;
            _eventPublisher = eventPublisher;
        }
        // GET api/values
        public async Task<IEnumerable<string>> Get()
        {
            await _eventPublisher.PublishAsync(new OrderDeletedEventArgs() { OrderId = 1 });
            _componentContext.ResolveKeyed<IEventTypeStrategyFinder>("1").ExecuteStrategy();
            _componentContext.ResolveKeyed<IEventTypeStrategyFinder>("4").ExecuteStrategy();

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
