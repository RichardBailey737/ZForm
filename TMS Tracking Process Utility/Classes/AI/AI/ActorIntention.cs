using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes.AI
{
    public class ActorIntention: IObjectLifeCycle, IMessageReceiver
    {
        public ActorIntention(Actor Parent)
        {
            this.Parent = Parent;
        }

        private List<Behavior> behaviors;

        public Actor Parent { get; private set; }
        public ActionBase GlobalState { get; set; }
        
        public Behavior this[int index]
        {
            get { return behaviors[index]; }
            set { behaviors[index] = value; }
        }

        public void Initalize()
        {
            behaviors = new List<Behavior>();
            behaviors.Add(new Behavior(this));
            this[0].Initalize();
        }

        public void Update()
        {
            foreach (var behavior in behaviors)
            {
                behavior.Update();                
            }
            if (GlobalState != null) GlobalState.Update();
        }

        public void Dispose()
        {
            foreach (var behavior in behaviors)
            {
                behavior.Dispose();
            }
            behaviors = null;
        }

        public bool HandleMessage(Msg message)
        {
            bool rtrn = false;
            foreach (Behavior b in behaviors)
            {
                if (b.CurrentAction.HandleMessage(message)) rtrn = true;
            }
            if (!rtrn)
            {
                return GlobalState.HandleMessage(message);
            }
            else
            {
                return true;
            }
        }
    }
}
