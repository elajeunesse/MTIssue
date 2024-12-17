using MassTransit;
using MassTransit.DependencyInjection;

namespace MTIssue.Config;

public class DefaultBusMassTransit : IDefaultBusMassTransit
{
    private readonly IPublishEndpoint _publishEndpoint;

    public DefaultBusMassTransit(Bind<IBus, IPublishEndpoint> publishEndpoint)
    {
        _publishEndpoint = publishEndpoint.Value;
    }

    public IPublishEndpoint PublishEndpoint { get { return _publishEndpoint; } }
}
