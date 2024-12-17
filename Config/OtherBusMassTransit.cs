using MassTransit.DependencyInjection;
using MassTransit;

namespace MTIssue.Config;

public class OtherBusMassTransit : IOtherBusMassTransit
{
    public OtherBusMassTransit(Bind<IOtherBus, IPublishEndpoint> massTransit)
    {
        PublishEndpoint = massTransit.Value;
    }

    public IPublishEndpoint PublishEndpoint { get; }
}
