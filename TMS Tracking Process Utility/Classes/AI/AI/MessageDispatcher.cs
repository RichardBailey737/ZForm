using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes.AI
{
    public static class MessageDispatcher
    {

        private static List<Msg> MessageQueue = new List<Msg>();

        private static void AddMessage(Msg msg)
        {
            MessageQueue.Add(msg);
            MessageQueue = MessageQueue.OrderBy(s => s.DispatchTime).ToList();
        }
        

        private static void Dispatch(Msg msg)
        {
            msg.Receiver.HandleMessage(msg);
        }

        public static void DispatchMessage(Msg msg)
        {
            if (msg.DispatchTime <= 0)
            {
                Dispatch(msg);
            }
            else
            {
                AddMessage(msg);
            }

        }

        public static void DisplatchDelayedMessages()
        {
            float currentTime = Globals.CurrentTime;

            while (MessageQueue.Count > 0 && MessageQueue[0].DispatchTime < currentTime)
            {
                Dispatch(MessageQueue[0]);
                MessageQueue.RemoveAt(0);
            }
        }

    }
}
