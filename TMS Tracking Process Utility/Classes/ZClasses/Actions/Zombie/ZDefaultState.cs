using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBDS.Classes.AI;

namespace TMS_Tracking_Process_Utility.Classes.Actions
{
    public class ZDefaultState: ActionBase
    {
        public ZDefaultState(Behavior Parent) : base(Parent)
        {
            
        }

        UndeadStats Stats { get { return (UndeadStats)ParentActor.Statistics; } }


        public override bool HandleMessage(Msg message)
        {
            switch (message.MessageType)
            {
                case Constants.Messages.ActorSeen:
                    Actor seen = (Actor)message.Data;
                    if (seen is HumanCitizen)
                    {
                        CitizenBaseStats cs = (CitizenBaseStats)seen.Statistics;
                        
                        //Is this the closest target?  if so, attack
                        if (Stats.Target == null) {
                            Stats.Target = seen;
                        } else if (Stats.Target != null && ((Stats.Target.Statistics as CitizenBaseStats).LocationVec.Subtract(Stats.LocationVec).LengthSquared() > cs.LocationVec.Subtract(Stats.LocationVec).LengthSquared())) {
                            Stats.Target = seen;
                        }
                        if (ParentActor.Intention.Primary.CurrentAction

                    }
                    return true;

                default:
                    return false;
            }


        }

    }
}
