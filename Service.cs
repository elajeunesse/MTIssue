using MTIssue.Config;

namespace MTIssue;

public class Service
{
    private readonly IDefaultBusMassTransit _defaultBusMassTransit;

    public Service(IDefaultBusMassTransit defaultBusMassTransit)
    {
        _defaultBusMassTransit = defaultBusMassTransit;
    }

    public async Task Publish()
    {
        var message = new OtherMessage
        {
            Number = 42
        };

        await _defaultBusMassTransit.PublishEndpoint.Publish(message);
    }
}
