using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes.AI
{
    public interface IMessageReceiver
    {
        bool HandleMessage(Msg message);
    }
}
