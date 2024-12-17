using Microsoft.AspNetCore.Mvc;
using MTIssue.Config;

namespace MTIssue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublishController : ControllerBase
    {
        private readonly IOtherBusMassTransit _otherBusMassTransit;

        public PublishController(IOtherBusMassTransit otherBusMassTransit)
        {
            _otherBusMassTransit = otherBusMassTransit;
        }

        [HttpGet]
        [Route("publish")]
        public async Task Get()
        {
            var message = new Message
            {
                Text = "Hello, World!"
            };

            await _otherBusMassTransit.PublishEndpoint.Publish(message);
        }
    }
}
