using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBDS.Classes.AI;

namespace Zombies.Actions.Human
{
    public class Flee : ActionBase
    {
        public Flee(Behavior Parent)
            : base(Parent)
        {

        }

        public override ActionTransition Start(ActionTransition PreviousAction)
        {
            //ParentActor.Locomotion.LocomotionProxy.SetTarget(((SenseQuery)PreviousAction.Data).SensedActors[0]);
            return null;
        }

        public override IEnumerable<ActionTransition> Update()
        {
           // ParentActor.Locomotion.LocomotionProxy.Flee(ParentActor.Statistics.Speed);

            Console.WriteLine("Test 1");

            yield return new ActionTransition() { Data = 5.0, Transition = TransitionType.Wait };

            Console.WriteLine("Test 2");

            yield return null;
        }
    }
}
