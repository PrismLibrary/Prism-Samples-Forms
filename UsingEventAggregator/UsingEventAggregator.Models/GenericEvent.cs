using Prism.Events;

namespace UsingEventAggregator.Models
{
    public class GenericEvent<T> : PubSubEvent<T> { }
}
