using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes.AI
{
    /// <summary>
    /// Sound and vision queries
    /// </summary>
    public class ActorSensoryPerception : IObjectLifeCycle
    {
        public ActorSensoryPerception(Actor ParentActor)
        {
            this.ParentActor = ParentActor;
            //this.SensoryPerceptionProxy = Proxy;
        }

        //public ISensoryProxy SensoryPerceptionProxy { get; private set; }

      

        public Actor ParentActor { get; private set; }


        public virtual void Initalize()
        {
            
        }

        public virtual void Update()
        {
            
        }

        public virtual void Dispose()
        {
            
        }
    }

    public class SenseQuery
    {
        public SenseQuery()
        {
            SensesSomething = false;
        }
        public bool SensesSomething { get; set; }
        public bool SeesSomething { get; set; }
        public bool HearsSomething { get; set; }
        public List<Actor> SensedActors { get; set; }
        public float IdentifiedPercent { get; set; }
    }
}
