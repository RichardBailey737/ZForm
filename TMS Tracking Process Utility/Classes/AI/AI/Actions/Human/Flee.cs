using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes.AI.Actions.Human
{
    public class Flee : ActionBase
    {
        public Flee(Behavior Parent)
            : base(Parent)
        {

        }

        public override ActionTransition Start(ActionTransition PreviousAction)
        {
            ParentActor.Locomotion.LocomotionProxy.SetTarget(((SenseQuery)PreviousAction.Data).SensedActors[0]);
            return null;
        }

        public override ActionTransition Update()
        {
           // ParentActor.Locomotion.LocomotionProxy.Flee(ParentActor.Statistics.Speed);

            return base.Update();
        }
    }
}
