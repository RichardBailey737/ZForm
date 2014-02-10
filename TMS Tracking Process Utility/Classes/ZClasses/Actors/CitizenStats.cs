using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using BBDS.Classes.AI;
using System.ComponentModel;

namespace TMS_Tracking_Process_Utility.Classes
{

    public class CitizenStats : ActorStatistics
    {

        /// <summary>
        /// 1 = Head in a bucket, 10 = SEAL on patrol
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [Browsable(true), Category("Active Properties"), Description("Alert to the zombie situation.  0 = No idea what is going on, 10 = fully aware zombies exist and are attacking people.")]
        public int Alertness { get; set; }

        /// <summary>
        /// 1 = not hungry, 10 = starving near death
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [Browsable(true), Category("Active Properties"), Description("How hungry they are.  1 = Not hungry, 10 = Starving")]
        public int Hunger { get; set; }

        /// <summary>
        /// 1 = Got nothing, 10 = wizzing down my leg
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [Browsable(true), Category("Active Properties"), Description("Bathroom need.  1 = nope, 10 = Oops")]
        public int Relief { get; set; }

        /// <summary>
        /// 1 = Watching a disney movie, 10 = legs wont move, whats that smell?
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [Browsable(true), Category("Active Properties"), Description("How scared they are.  1 = Watching a disney movie, 10 = Bathroom problem solved")]
        public int Scared { get; set; }

        /// <summary>
        /// 1 = Gandhi, 10 = SEAL
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [Browsable(true), Category("Static Properties"), Description("Ability to fight.  1 = No ability.  10 = Former member of a seal team")]
        public int CombatAbility { get; set; }

        /// <summary>
        /// 1 = Ran with scissors before the scissor accident, 10 = Stephen Hawking
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [Browsable(true), Category("Static Properties"), Description("Smarts.  1 = Runs with scissors, 10 = Moves scissors with their mind")]
        public int Inteligence { get; set; }



        /// <summary>
        /// Uses speed and action to return their current movement speed
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [Browsable(true), Category("Static Properties"), Description("Their movement speed dictated by their speed value.  During normal times they move at 2 (unless they can't move that fast).  While fleeing they move at their top speed which is speed/2")]
        public int MovementSpeed
        {
            get
            {
                if (_speed / 1 > 2)
                {
                    return _speed / 1;
                }
                else
                {
                    return 2;
                }

            }
            set { _speed = value; }
        }




        private int _speed;

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        /// <summary>
        /// 1 = Immenent Death, 5 = Hurt but could get better with medical attention, 10 = Fine
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [Browsable(true), Category("Active Properties"), Description("How hurt is this citizen. 1 = Immenent Death, 5 = Hurt but could get better with medical attention, 10 = Fine")]
        public int Hurt { get; set; }

        /// <summary>
        /// 1 = Can't keep eyes open, 10 = hopped up on caffiene
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [Browsable(true), Category("Active Properties"), Description("How tired they are.  1 = About to pass out, 10 = Wide awake")]
        public int Tired { get; set; }


        [Browsable(true), Category("Active Properties"), Description("Is this citizen asleep or not")]
        public bool IsAsleep { get; set; }

        [Browsable(true), Category("Static Properties"), Description("Sex of the person (yes please)")]
        public PersonSex Sex { get; set; }
        [Browsable(true), Category("Active Properties"), Description("Are they alive? (Zombies can die too)")]
        public bool Alive { get; set; }


        //Where are they?
        [Browsable(false)]
        public Structure InBuilding { get; set; }
        [Browsable(false)]
        public GeomLib.Point2D Location { get; set; }
        [Browsable(false)]
        public Map Area { get; set; }
        [Browsable(false)]
        public Hashtable BuildingHistory { get; set; }

        //What do they have?
        [Browsable(true), Category("Active Properties"), Description("Has a gun?")]
        public bool HasGun { get; set; }
        [Browsable(true), Category("Active Properties"), Description("Has some kind of melee weapon?")]
        public bool HasMelee { get; set; }

        /// <summary>
        /// Ammo they are carrying.  Max of 100
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [Browsable(true), Category("Active Properties"), Description("Amunition for their weapon")]
        public int Ammo { get; set; }

        /// <summary>
        /// Number of rations they have.  1 ration per day.  Max of 15
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [Browsable(true), Category("Active Properties"), Description("Amount of food they are carrying")]
        public int Food { get; set; }

        [Browsable(true), Category("Active Properties"), Description("Citizen or Zombie they are looking at, fighting or running from.")]
        public Actor Target { get; set; }

        [Browsable(false)]
        public Structure TargetBuilding { get; set; }

        [Browsable(false)]
        public GeomLib.Vector2D FacingVector { get; set; }


    }

    public enum PersonSex {
        Male = 1,
        Female = 2
    }
}