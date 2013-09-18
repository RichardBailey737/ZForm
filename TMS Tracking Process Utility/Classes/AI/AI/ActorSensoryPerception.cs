using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes.AI
{
    /// <summary>
    /// Sound and vision queries
    /// </summary>
    public class ActorSensoryPerception
    {
        public ActorSensoryPerception(Actor ParentActor, ISensoryProxy Proxy)
        {
            this.ParentActor = ParentActor;
            this.SensoryPerceptionProxy = Proxy;
        }

        public ISensoryProxy SensoryPerceptionProxy { get; private set; }

        public SenseQuery SeesZombie()
        {
            List<Actor> SeenActors = SensoryPerceptionProxy.CanSee(ParentActor.Statistics.VisionDistance);
            if (SeenActors.Count > 0)
            {
                return new SenseQuery { SeesSomething = true, HearsSomething = false, IdentifiedPercent = 1f, SensesSomething = true, SensedActors = SeenActors };
            }
            else
            {
                return new SenseQuery();
            }
            
        }

        public Actor ParentActor { get; private set; }

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
