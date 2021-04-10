using AutoMapper;
using EventBuss.Messages.Event;
using MassTransit;
using MassTransit.Mediator;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMqMessageEvent.EventReceiver
{
    public class MessageConsumer : IConsumer<MessageEvent>
    {

        public MessageConsumer()
        {
        }

        public async Task Consume(ConsumeContext<MessageEvent> context)
        {
            // you can check message
        }
    }
}
