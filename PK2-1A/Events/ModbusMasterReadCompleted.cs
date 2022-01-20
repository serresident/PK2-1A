using Prism.Events;

namespace belofor.Events
{
    public class ModbusMasterReadCompleted : PubSubEvent { }
    public class TcpConnect : PubSubEvent<bool> { }
}