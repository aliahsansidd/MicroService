using System;

namespace EventBuss.Messages.Event
{
    public class IntegrationBaseEvent
    {
        public IntegrationBaseEvent()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
        public IntegrationBaseEvent(Guid id,DateTime date)
        {
            Id = id;
            CreatedDate = date;
        }
        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
    }
}
