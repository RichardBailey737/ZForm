using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes.AI.Actions.Human
{
    public class Walk : ActionBase
    {
        public Walk(Behavior Parent)
            : base(Parent)
        {

        }
		
		Technique CurrentTechnique = null;
		ActionTransition Transition = new ActionTransition();
		
        public override ActionTransition Start(ActionTransition PreviousAction)
        {
			Transition.FromAction = this;
			ParentActor.Locomotion.LocomotionProxy.GoToTarget(MovementSpeed.Walk);
            return null;
        }

        public override ActionTransition Update()
        {
			//ParentActor.Body.BodyProxy.SetAnimationState();
			
            return base.Update();
        }
    }
}
