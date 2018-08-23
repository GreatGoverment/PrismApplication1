using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApplication.Request
{
    public class MessageNotification : Notification
    {
        public string IconKind { get; set; }
        public string Message { get; set; }
        public string ButtonContent { get; set; }
    }
}
