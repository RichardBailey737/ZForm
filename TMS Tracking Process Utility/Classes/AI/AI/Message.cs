using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes.AI
{
    public class Msg
    {
        public Msg(Actor Sender, Actor Receiver, int Msg)
        {
            Const(Sender, Receiver, Msg, 0, null);
        }

        public Msg(Actor Sender, Actor Receiver, int Msg, float Delay)
        {
            Const(Sender, Receiver, Msg, Delay, null);
        }

        public Msg(Actor Sender, Actor Receiver, int Msg, float Delay, object Data)
        {
            Const(Sender, Receiver, Msg, Delay, Data);
        }

        private void Const(Actor Sender, Actor Receiver, int Msg, float Delay, object Data)
        {
            this.Sender = Sender;
            this.Receiver = Receiver;
            this.MessageType = Msg;
            this.Data = Data;
            this.DispatchTime = Globals.CurrentTime + Delay;
        }
        public Actor Sender { get; set; }
        public Actor Receiver { get; set; }

        public int MessageType { get; set; }
        public double DispatchTime { get; set; }
        public object Data { get; set; }
    }


}
