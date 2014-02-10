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
            this.ActionQueue = new List<ActionTransition>();
        }

        public ActionPool ActionStorage { get; private set; }
        public ActionBase SuspendedAction { get; private set; }
        public ActionBase CurrentAction { get; private set; }
        public ActorIntention Parent { get; private set; }
		public Actor ParentActor { get; private set; }


        private float? WaitUntilTime = null;
        private List<ActionTransition> ActionQueue;

        /// <summary>
        /// Gets a value indicating whether the wait time is over.
        /// </summary>
        /// <value>
        /// <c>true</c> if wait over; otherwise, <c>false</c>.
        /// </value>
        public bool WaitOver
        {
            get
            {
                if (WaitUntilTime.HasValue)
                {
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

        public void Add(ActionTransition ActionToQueue) {
            ActionQueue.Add(ActionToQueue);
        }

        public void PriorityAdd(ActionTransition ActionToQueue)
        {
            for (int i = 0; i < ActionQueue.Count; i++)
			{
                if (ActionToQueue.Priority > ActionQueue[i].Priority) ActionQueue.Insert(i, ActionToQueue);
            }
        }

        /// <summary>
        /// Sets a wait time value.  When the wait time is over, the WaitOver property returns true;
        /// </summary>
        /// <param name='WaitTime'>
        /// Wait time in seconds.
        /// </param>
        public void WaitUntil(float WaitTime)
        {
            WaitUntilTime = Globals.CurrentTime + WaitTime;
        }
		
        public void Initalize()
        {
            ActionStorage = new ActionPool(this);
            ActionStorage.Initalize();
        }

        IEnumerable<ActionTransition> updateReturn;
        IEnumerator<ActionTransition> iterator;
        ActionTransition returnedTransition;


        public void Update()
        {
            if (CurrentAction != null && WaitOver)
            {
                if (updateReturn == null)
                {
                    updateReturn = CurrentAction.Update();
                    iterator = updateReturn.GetEnumerator();
                }

                iterator.MoveNext();
                returnedTransition = iterator.Current;

                if (returnedTransition != null)
                {
                    ProcessTransition(returnedTransition);
                }


            }
            else if (CurrentAction == null && ActionQueue.Count > 0)
            {
                returnedTransition = ActionQueue[0];
                ActionQueue.RemoveAt(0);
                ProcessTransition(returnedTransition);
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
                case TransitionType.Wait:
                    WaitUntil((float)Convert.ToDouble(transition.Data));
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
