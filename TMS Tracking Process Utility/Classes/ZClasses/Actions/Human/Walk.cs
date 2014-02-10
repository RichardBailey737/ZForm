using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBDS.Classes.AI;

namespace TMS_Tracking_Process_Utility.Classes.Actions
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
			//Transition.FromAction = this;
			//ParentActor.Locomotion.LocomotionProxy.GoToTarget(MovementSpeed.Walk);
            Console.WriteLine("Action started");
            return null;
        }

        public override IEnumerable<ActionTransition> Update()
        {
			//ParentActor.Body.BodyProxy.SetAnimationState();
            Console.WriteLine("Hit point 1");
            yield return null;

            Console.WriteLine("Hit point 2");
            Transition.Transition = TransitionType.Wait;
            Transition.Data = 5000;
            yield return Transition;

            Console.WriteLine("Hit point 3");
            
        }
    }
}
