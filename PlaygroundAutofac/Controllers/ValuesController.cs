using System.Collections.Generic;
using System.Web.Http;
using Autofac;

namespace PlaygroundAutofac.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly ISomethingService _somethingService;
        private readonly IEventTypeStrategyFinder _eventTypeStrategyFinder;
        private readonly IComponentContext _componentContext;

        public ValuesController(ISomethingService somethingService, IEventTypeStrategyFinder eventTypeStrategyFinder, IComponentContext componentContext)
        {
            _somethingService = somethingService;
            _eventTypeStrategyFinder = eventTypeStrategyFinder;
            _componentContext = componentContext;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
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
