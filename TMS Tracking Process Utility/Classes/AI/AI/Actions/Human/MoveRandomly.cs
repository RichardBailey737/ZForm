using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes.AI.Actions.Human
{
    public class MoveRandomly: ActionBase
    {
        public MoveRandomly(Behavior Parent) : base(Parent)
        {
            
        }
        public override ActionTransition Start(ActionTransition PreviousAction)
        {
            //ParentActor.Locomotion.LocomotionProxy.SetRandomDestination();
            return null;
        }

        public override ActionTransition Resume(ActionTransition PreviousAction)
        {
            return base.Resume(PreviousAction);
        }

        public override ActionTransition Suspend(ActionTransition PreviousAction)
        {
            return base.Suspend(PreviousAction);
        }

        
        public override ActionTransition Update()
        {
//            if (ParentActor.Locomotion.LocomotionProxy.GoToTarget(ParentActor.Statistics.Speed)) {
//               ParentActor.Locomotion.LocomotionProxy.SetRandomDestination();
//            }
//            //ParentActor.Engine.Seek(ParentActor.Statistics.Speed);
//            SenseQuery q = ParentActor.SensoryPerception.SeesZombie();
//            if (q.SensesSomething)
//            {
//                return new ActionTransition { FromAction = this, Reason = "Sees Zombie", Transition = TransitionType.Change, ToAction = "Flee", Data = q };
//            }
//            else
//            {
//                return null;
//            }
			return null;
        }

        public override void End()
        {
            base.End();
        }

    }
}
