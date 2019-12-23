namespace PlaygroundAutofac
{
    public class OrderDeletedEventArgs : IEventArgs
    {
        public int OrderId { get; set; }
    }

    public interface IEventArgs
    {
    }
}