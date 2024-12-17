using MassTransit;

namespace MTIssue.Config;

public interface IMultiMassTransit
{
    public IPublishEndpoint PublishEndpoint { get; }
}
