using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes.AI.Actions.Human
{
    public class LowPunch : ActionBase
    {
        public LowPunch(Behavior Parent)
            : base(Parent)
        {

        }
		
		ActionTransition Transition = new ActionTransition();
		Techniques.LowPunch lp;
		
        public override ActionTransition Start(ActionTransition PreviousAction)
        {
			Transition.FromAction = this;
			lp = (Techniques.LowPunch)PreviousAction.Data;
			//ParentActor.Body.BodyProxy.SetAnimationState();
			MessageDispatcher.DispatchMessage(new Msg(ParentActor.ID, lp.TargetID, MsgType.Attack, .3f, "LOWPUNCH"));
			WaitUntil(.5f);
            return null;
        }

        public override ActionTransition Update()
        {
			if (WaitOver) {
				Transition.Reason = "Attack Completed";
				Transition.Transition = TransitionType.Resume;
				return Transition;
			}

			return base.Update();
        }
    }
}
