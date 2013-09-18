using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBDS.Classes;

namespace BBDS.Classes.AI
{
    public class Behavior : IObjectLifeCycle
    {
        public Behavior(ActorIntention Parent)
        {
            this.Parent = Parent;
			this.ParentActor = Parent.Parent;
        }

        public ActionPool ActionStorage { get; private set; }
        public ActionBase SuspendedAction { get; private set; }
        public ActionBase CurrentAction { get; private set; }
        public ActorIntention Parent { get; private set; }
		public Actor ParentActor { get; private set; }
		
        public void Initalize()
        {
            ActionStorage = new ActionPool(this);
            ActionStorage.Initalize();
        }

        public void Update()
        {
            if (CurrentAction != null)
            {
                ActionTransition returnedTransition = CurrentAction.Update();
                if (returnedTransition != null)
                {
                    ProcessTransition(returnedTransition);
                }
            }
        }

        private void ProcessTransition(ActionTransition transition)
        {

            switch (transition.Transition)
            {
                case TransitionType.Change:
                    ChangeTo(transition);
                    break;
                case TransitionType.Suspend:
                    Suspend(transition);
                    break;
                case TransitionType.Resume:
                    Resume(transition);
                    break;
                case TransitionType.End:
                    CurrentAction.End();
                    CurrentAction = null;
                    break;

            }

        }

        public void ChangeTo(ActionTransition transition)
        {
            if (CurrentAction != null)
            {
                CurrentAction.End();
            }
            CurrentAction = ActionStorage.GetAction(transition.ToAction);
            ActionTransition tran = CurrentAction.Start(transition);
            if (tran != null) ProcessTransition(tran);
        }

        private void Suspend(ActionTransition transition)
        {
            CurrentAction.Suspend(transition);
            SuspendedAction = CurrentAction;
            CurrentAction = ActionStorage.GetAction(transition.ToAction);
            ActionTransition tran = CurrentAction.Start(transition);
            if (tran != null) ProcessTransition(tran);
        }

        private void Resume(ActionTransition transition)
        {
            CurrentAction.End();
            CurrentAction = SuspendedAction;
            SuspendedAction = null;
            ActionTransition tran = CurrentAction.Resume(transition);
            if (tran != null) ProcessTransition(tran);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
