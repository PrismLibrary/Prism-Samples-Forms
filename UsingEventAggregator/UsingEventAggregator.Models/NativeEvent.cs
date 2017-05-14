using System;
using Prism.Events;

namespace UsingEventAggregator.Models
{
    public class NativeEvent : PubSubEvent<NativeEventArgs> { }
}
