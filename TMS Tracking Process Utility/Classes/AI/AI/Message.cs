using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes.AI
{
    public class Msg
    {
        public Msg(int Sender, int Receiver, MsgType Msg)
        {
            Const(Sender, Receiver, Msg, 0, null);
        }

        public Msg(int Sender, int Receiver, MsgType Msg, float Delay)
        {
            Const(Sender, Receiver, Msg, Delay, null);
        }

        public Msg(int Sender, int Receiver, MsgType Msg, float Delay, object Data)
        {
            Const(Sender, Receiver, Msg, Delay, Data);
        }

        private void Const(int Sender, int Receiver, MsgType Msg, float Delay, object Data)
        {
            this.Sender = Sender;
            this.Receiver = Receiver;
            this.MessageType = Msg;
            this.Data = Data;
            this.DispatchTime = Globals.CurrentTime + Delay;
        }
        public int Sender { get; set; }
        public int Receiver { get; set; }

        public MsgType MessageType { get; set; }
        public double DispatchTime { get; set; }
        public object Data { get; set; }
    }

    public enum MsgType
    {
        Default = 0,
		Attack = 1
		
    }
}
