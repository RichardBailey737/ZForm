using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBDS.Classes.AI;
using GeomLib;

namespace TMS_Tracking_Process_Utility.Classes
{
    public class CitizenSensoryPerception : ActorSensoryPerception
    {
        public CitizenSensoryPerception(Map AreaMap, Actor Parent) : base(Parent)
        {
            VisionRefreshRate = 500;
            Area = AreaMap;
        }

        public Vector2D LookDirection;
        public Vector2D FutureLookDirection;
        public float VisionDistance;
        /// <summary>
        /// 
        /// </summary>
        const float VisionAngle = 90;

        public long VisionRefreshRate { get; set; }
        public float HeadTurnSpeed { get; set; }

        private long NextVisionCheck = 0;
        private Map Area;

        public override void Update()
        {
            base.Update();

            if (GameProject.GameLoop.GameTime >= NextVisionCheck)
            {


                NextVisionCheck = GameProject.GameLoop.GameTime + VisionRefreshRate;
            }


        }

        public void CheckVision()
        {
            //Get the list of actors in nearby grid squares.
            //Check for 100% cover or inside a building
            //Do a distance squared check to find actors within the vision radius
            //Do an angle check for any actors outside of the 
        }

        public void GenerateSound(string Sound, int Intensity)
        {
        }

        public override bool HandleMessage(Msg msg)
        {
            return false;
        }

    }
}
