using System;

namespace PlaygroundAutofac
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class EventTypeAttribute : Attribute
    {
        public EventTypeAttribute(string eventTypeId)
        {
            EventTypeId = eventTypeId;
        }
        public string EventTypeId { get; }
    }
}