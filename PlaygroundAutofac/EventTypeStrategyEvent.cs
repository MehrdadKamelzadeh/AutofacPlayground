namespace PlaygroundAutofac
{
    [EventType("2")]
    [EventType("4")]
    public  class EventTypeStrategyEvent : IEventTypeStrategyFinder
    {
        public void ExecuteStrategy()
        {
            var x = 2;
        }
    }
}