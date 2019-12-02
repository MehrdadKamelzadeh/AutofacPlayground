namespace PlaygroundAutofac
{
    [EventType("1")]
    [EventType("3")]
    public class EventTypeStrategyOdd : IEventTypeStrategyFinder
    {
        public void ExecuteStrategy()
        {
            var y = 1;
        }
    }
}