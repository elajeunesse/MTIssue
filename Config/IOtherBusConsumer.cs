using MassTransit;

namespace MTIssue.Config;

public interface IOtherBusConsumer<in TMessage> : IConsumer<TMessage>
    where TMessage : class
{
}
