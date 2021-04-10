using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBuss.Messages.Event
{
    public class MessageEvent :IntegrationBaseEvent
    {
        public string Message { get; set; }
    }
}
