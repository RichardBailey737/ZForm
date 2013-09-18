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
		
		private float? WaitUntilTime = null;
		
		/// <summary>
		/// Gets a value indicating whether the wait time is over.
		/// </summary>
		/// <value>
		/// <c>true</c> if wait over; otherwise, <c>false</c>.
		/// </value>
		public bool WaitOver { get 
			{
				if (WaitUntilTime.HasValue) {
					if (Globals.CurrentTime >= WaitUntilTime) 
					{
						WaitUntilTime = null;
						return true;
					}
				    else
						return false;
				}
				return true;
			}
		}
	
		/// <summary>
		/// Sets a wait time value.  When the wait time is over, the WaitOver property returns true;
		/// </summary>
		/// <param name='WaitTime'>
		/// Wait time in seconds.
		/// </param>
		public void WaitUntil(float WaitTime) {
			WaitUntilTime = Globals.CurrentTime + WaitTime;
		}

        public virtual ActionTransition Start(ActionTransition PreviousAction)
        {
            Console.Write("Starting new action: ");
            Console.WriteLine(PreviousAction.Reason);
            return null;

        }

        public virtual ActionTransition Update()
        {
            return null;
        }

        public virtual void End()
        {
            
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
