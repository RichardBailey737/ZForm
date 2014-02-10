using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMS_Tracking_Process_Utility.Classes
{
    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using BBDS.Classes.AI;
    using BBDS.Classes;

    public class HumanCitizen : Actor
    {
        public HumanCitizen(Map map)
            : base()
        {
            this.Statistics = new CitizenStats();
            this.Locomotion = new CitizenLocomotion(this, map);

        }

        public CitizenStats HumanStats { get { return (CitizenStats)this.Statistics; } } 

        public override void Initalize()
        {
            base.Initalize();

            CitizenStats stats = (CitizenStats)this.Statistics;

            var _with1 = stats;
            _with1.Alive = true;

            _with1.Alertness = 0;
            _with1.Hunger = 0;
            _with1.Relief = 0;
            _with1.Scared = 0;
            _with1.Hurt = 10;


            _with1.CombatAbility = Utilities.Random1to10Weighted(25);
            //Only 25% of the population has an above 5 combat ability
            _with1.Inteligence = Utilities.Random1to10();
            _with1.Speed = Utilities.Random1to10();
            if (_with1.Speed == 1)
                _with1.Speed = 2;

            _with1.Tired = Utilities.Random1to10();

            if (Utilities.RTF())
            {
                _with1.Sex = PersonSex.Male;
            }
            else
            {
                _with1.Sex = PersonSex.Female;
            }

            _with1.HasGun = Utilities.RTFWeighted(10);
            //only 10% of the population is armed
            if (_with1.HasGun)
                _with1.Ammo = Utilities.R(10, 100);
            //Normally even a copy wouldn't carry around too much ammo
            _with1.HasMelee = Utilities.RTFWeighted(5);
            //not too many people carry around a melee weapon
            _with1.Food = Utilities.R(0, 2);
            //Most people don't carry around much food.  Maybe a lunch for work.



            this.Intention[0].ChangeTo(new ActionTransition
            {
                ToAction = Globals.Actions.MoveRandomly,
                Reason = "Inital state"
            });


        }

    }

}
