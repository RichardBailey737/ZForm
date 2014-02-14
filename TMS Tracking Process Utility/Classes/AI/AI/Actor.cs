using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBDS.Classes;

//NOTE!  All the Is null checks MUST be temporary!  Remove them ASAP!
namespace BBDS.Classes.AI
{
    public class Actor: IObjectLifeCycle, IMessageReceiver
    {
        public Actor(IBodyProxy BodyProxyClass, ActorLocomotion LocomotionProxyClass, ISensoryProxy SensoryProxyClass, ActorStatistics StatsObject)
        {

            this.Statistics = StatsObject;
            this.SensoryPerception = new ActorSensoryPerception(this);
            this.Locomotion = LocomotionProxyClass;
            this.Body = new ActorBody(this, BodyProxyClass);

        }
		
		public Actor() {
			this.Statistics = new ActorStatistics();
		}

        public int ID { get; private set; }
        public ActorIntention Intention { get; set; }
        public ActorBody Body { get; set; }
        public ActorLocomotion Locomotion { get; set; }
        public ActorSensoryPerception SensoryPerception { get; set; }
        public ActorStatistics Statistics { get; set; }
        

        #region ObjectLifeCyle
        public virtual void Initalize()
        {
           
            ID = Globals.GenerateID();
            Intention = new ActorIntention(this);
            Intention.Initalize();
            Globals.Actors.Add(this);
            if (Body != null) Body.BodyProxy.Initalize();
            if (Locomotion != null) Locomotion.Initalize();
            if (SensoryPerception != null) SensoryPerception.Initalize();
            

        }
        
        public virtual void Update()
        {
			Intention.Update();
        	if (Locomotion != null) Locomotion.Update();
        }

        public virtual void Dispose()
        {
            Intention.Dispose();
        }
        #endregion



        public bool HandleMessage(Msg message)
        {
            return Intention.HandleMessage(message);
        }
    }
}
