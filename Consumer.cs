using MassTransit;
using MTIssue.Config;

namespace MTIssue;

public class MyConsumer : IOtherBusConsumer<Message>
{
    private readonly Service _service;

    public MyConsumer(Service service)
    {
        _service = service;
    }

    public async Task Consume(ConsumeContext<Message> context)
    {
        await _service.Publish();
    }
}
