using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBDS.Classes.AI;
//using UnityEngine;

namespace BBDS.Classes
{
    public static class Globals
    {
        private static ActorCollection mActors = new ActorCollection();

        public static ActorCollection Actors { get { return mActors; } }

        //public static float CurrentTime { get { return Time.time ; } }
        //public static float DeltaTIme { get { return Time.deltaTime; } }
        public static float CurrentTime { get { return GameProject.GameLoop.GameTime; } }
        public static float DeltaTime { get { return GameProject.GameLoop.DeltaTime; } } 

        private static int MaxID = 0;
        public static int GenerateID()
        {
            return ++MaxID;
        }

        public static float MaxCameraVelocity = 25;
        public static float MaxCameraHeight = 60;
        public static float MinCameraHeight = 5;
        public static float CameraMovementModifier = .8f;

        public static float ActorMovementModifier = 10f;
        public static float ActorDrag = .8f;


        

        public static string Output = "";
		public static bool paused = false;
		public static bool isPaused {
			get { return paused; }
			set { paused = value; }
		}

    }

    public class ActorCollection
    {
        private Dictionary<int, Actor> ActorList = new Dictionary<int, Actor>();

        public Dictionary<int, Actor> Items { get { return ActorList; } } 

        public Actor this[int index]
        {
            get { return ActorList[index]; }
        }

        public void Add(Actor actor)
        {
            if (!ActorList.ContainsKey(actor.ID)) ActorList.Add(actor.ID, actor);
        }

        public void Remove(int ID)
        {
            if (ActorList.ContainsKey(ID)) ActorList.Remove(ID);
        }

        public void Remove(Actor actor)
        {
            Remove(actor.ID);
        }
    }

    public class IntPT {
        public IntPT(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public IntPT() {
        }


        public int x = 0;
        public int y = 0;

    }
}
