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
            ActorsInSight = new List<Actor>();
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

        public long ListenDistance { get; set; }

        private long NextVisionCheck = 0;
        private Map Area;

        public List<Actor> ActorsInSight { get; private set; }
        private CitizenStats Stats { get { return (CitizenStats)ParentActor.Statistics; } }

        public override void Update()
        {
            base.Update();

            if (GameProject.GameLoop.GameTime >= NextVisionCheck)
            {


                NextVisionCheck = GameProject.GameLoop.GameTime + VisionRefreshRate;
            }


        }

        List<Actor> WorkingActorList = new List<Actor>();

        public void CheckVision()
        {
            //Get the list of actors in nearby grid squares.
            //Check for 100% cover or inside a building
            //Do a distance squared check to find actors within the vision radius
            //Do an angle check for any actors outside of the vision range
            //Compare the current list of what actors are in sight 
            //  to the list of ones it sees now.  If the status changes, send a message


            WorkingActorList.Clear();
            List<Actor> PotentialActorsInSight = Area.Grid.ActorsInRange(VisionDistance, (ParentActor.Locomotion as CitizenLocomotion).CurrentGridPoint);
            bool vis = true;
            double VDSquared = Convert.ToDouble(VisionDistance * VisionDistance);
            Msg m;
            foreach (var visAct in ActorsInSight)
            {
                vis = true;
                if ((visAct.Statistics as CitizenStats).Cover > 0) vis = Utilities.RTFWeighted(100 - (visAct.Statistics as CitizenStats).Cover);
                if (vis && (Stats.LocationVec.Subtract((visAct.Statistics as CitizenStats).LocationVec).LengthSquared() < VDSquared)) vis = false;
                if (vis && (LookDirection.AngleTo((visAct.Statistics as CitizenStats).LocationVec) > VisionAngle)) vis = false;
                if (vis)
                {
                    ActorsInSight.Add(visAct);
                    WorkingActorList.Add(visAct);
                    m = new Msg(ParentActor ,ParentActor, Constants.Messages.ActorSeen, 0f, visAct);
                    MessageDispatcher.DispatchMessage(m);
                }

            }

            for (int i = ActorsInSight.Count()-1; i >=0; i--)
            {
                if (!WorkingActorList.Contains(ActorsInSight[i])) {
                    m = new Msg(ParentActor, ParentActor, Constants.Messages.ActorNoLongerSeen, 0f, ActorsInSight[i]);
                    ActorsInSight.RemoveAt(i);
                }
            }

        }

        public void GenerateSound(string Sound, int Intensity)
        {
            //Get a list of actors in the nearby grid squares
            //If the actor is in a building, cut the intensity by half
            //Intensity varies inversely to the distance away 
            //if the modified intensity (squared) is bigger than the distance squared then            
            //Send messages to those actors.
            List<Actor> PotentiallyAudibleActors = Area.Grid.ActorsInRange(ListenDistance, (ParentActor.Locomotion as CitizenLocomotion).CurrentGridPoint);
            int tempInt;
            double dist;
            Msg m;
            foreach (var PAA in PotentiallyAudibleActors)
            {
                tempInt = Intensity;
                if ((PAA.Statistics as CitizenBaseStats).InBuilding != Stats.InBuilding) tempInt /= 2;
                if (tempInt >= 1) {
                    dist = ((PAA.Statistics as CitizenBaseStats).LocationVec.Subtract(Stats.LocationVec)).Length();
                    tempInt = tempInt - (int)dist;
                    if (tempInt > 0)
                    {
                        m = new Msg(ParentActor, PAA, Constants.Messages.SoundHeard, 0f, tempInt);
                        MessageDispatcher.DispatchMessage(m);
                    }

                }
                
                
            }

        }

        public override bool HandleMessage(Msg msg)
        {
            return false;
        }

    }
}
