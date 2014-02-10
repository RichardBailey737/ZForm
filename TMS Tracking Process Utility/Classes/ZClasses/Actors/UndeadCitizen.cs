using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBDS.Classes.AI;

namespace TMS_Tracking_Process_Utility.Classes
{
    public class UndeadCitizen : Actor
    {

        public UndeadCitizen(Map map)
            : base()
        {
            this.Statistics = new UndeadStats();
            this.Locomotion = new CitizenLocomotion(this, map);

        }

        public UndeadStats undeadStats { get { return (UndeadStats)this.Statistics; } } 

        public override void Initalize()
        {
            base.Initalize();

            undeadStats.Health = 10;
            undeadStats.MovementSpeed = Utilities.Random1to10();
            undeadStats.Speed = Utilities.Random1to10();
            undeadStats.Strength = Utilities.Random1to10();


            Intention.Primary.ChangeTo(new ActionTransition
            {
                ToAction = Globals.Actions.MoveRandomly,
                Reason = "Inital state"
            });
        }

    }
}
