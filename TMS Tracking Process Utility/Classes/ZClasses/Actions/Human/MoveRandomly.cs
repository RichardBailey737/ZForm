using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBDS.Classes.AI;

namespace TMS_Tracking_Process_Utility.Classes.Actions
{
    public class MoveRandomly: ActionBase
    {
        public MoveRandomly(Behavior Parent) : base(Parent)
        {
            loco = (CitizenLocomotion)ParentActor.Locomotion;
        }
        public override ActionTransition Start(ActionTransition PreviousAction)
        {
            loco.GenerateRandomPath();
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


        CitizenLocomotion loco;

        public override IEnumerable<ActionTransition> Update()
        {
            if (!loco.Moving())
            {
                loco.GenerateRandomPath();
            }
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
			yield return null;
        }

        public override void End()
        {
            base.End();
        }

    }
}
