using System;
using Prism.Events;

namespace UsingEventAggregator.Models
{
    public class IsFunChangedEvent : PubSubEvent<bool> { }
}
