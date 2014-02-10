using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes.AI
{
    public class ActionBase: IMessageReceiver
    {
        public ActionBase(Behavior Parent)
        {
            this.Parent = Parent;
            this.ParentActor = Parent.Parent.Parent;
        }

        public Behavior Parent { get; private set; }
        public Actor ParentActor { get; private set; }
        public ActionTransition actionTransition;


        public virtual ActionTransition Start(ActionTransition PreviousAction)
        {
            Console.Write("Starting new action: ");
            Console.WriteLine(PreviousAction.Reason);
            return null;

        }

        public virtual System.Collections.Generic.IEnumerable<ActionTransition> Update()
        {
            return null;
        }

        public virtual void End()
        {
            actionTransition = null;
            
        }

        public virtual ActionTransition Suspend(ActionTransition PreviousAction)
        {
            return null;
        }

        public virtual ActionTransition Resume(ActionTransition PreviousAction)
        {
            return null;
        }

        public virtual bool HandleMessage(Msg message)
        {
            return false;
        }
    }
}
