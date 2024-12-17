using MassTransit;

namespace MTIssue.Config;

public class DefaultBusMassTransit : IDefaultBusMassTransit
{
    private readonly IPublishEndpoint _publishEndpoint;

    public DefaultBusMassTransit(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public IPublishEndpoint PublishEndpoint { get { return _publishEndpoint; } }
}
