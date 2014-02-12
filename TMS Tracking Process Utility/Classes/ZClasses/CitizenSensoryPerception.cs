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
        public Vector2D LookDirection;
        public float VisionDistance;
        /// <summary>
        /// 
        /// </summary>
        const float VisionAngle = 90; 

        public override void Update()
        {
            base.Update();


        }
    }
}
