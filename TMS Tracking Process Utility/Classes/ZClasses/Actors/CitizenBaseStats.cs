using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBDS.Classes.AI;
using System.ComponentModel;
using System.Collections;

namespace TMS_Tracking_Process_Utility.Classes
{
    public class CitizenBaseStats : ActorStatistics
    {

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



        //Where are they?
        [Browsable(false)]
        public Structure InBuilding { get; set; }
        [Browsable(false)]
        private GeomLib.Point2D _location;
        public GeomLib.Point2D Location { get; set { _location = value; _LocationVec.X = value.X; _LocationVec.Y = value.Y; } }

        private GeomLib.Vector2D _LocationVec;
        public GeomLib.Vector2D LocationVec { get; private set; }

        [Browsable(false)]
        public Map Area { get; set; }
        [Browsable(false)]
        public Hashtable BuildingHistory { get; set; }

        [Browsable(false)]
        public GeomLib.Vector2D FacingVector { get; set; }


        [Browsable(true), Category("Active Properties"), Description("Citizen or Zombie they are looking at, fighting or running from.")]
        public Actor Target { get; set; }

        [Browsable(false)]
        public Structure TargetBuilding { get; set; }


    }
}
