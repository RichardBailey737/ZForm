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
        public Actor(IBodyProxy BodyProxyClass, ILocomotionProxy LocomotionProxyClass, ISensoryProxy SensoryProxyClass)
        {
            
            this.Statistics = new ActorStatistics();
            this.SensoryPerception = new ActorSensoryPerception(this, SensoryProxyClass);
            this.Locomotion = new ActorLocomotion(this, LocomotionProxyClass);
            this.Body = new ActorBody(this, BodyProxyClass);

        }
		
		public Actor() {
			this.Statistics = new ActorStatistics();
		}

        public int ID { get; private set; }
        public ActorIntention Intention { get; private set; }
        public ActorBody Body { get; private set; }
        public ActorLocomotion Locomotion { get; private set; }
        public ActorSensoryPerception SensoryPerception { get; private set; }
        public ActorStatistics Statistics { get; private set; }
        

        #region ObjectLifeCyle
        public virtual void Initalize()
        {
            if (Locomotion != null) Locomotion.LocomotionProxy.ParentActor = this;
            ID = Globals.GenerateID();
            Intention = new ActorIntention(this);
            Intention.Initalize();
            Globals.Actors.Add(this);
            if (Body != null) Body.BodyProxy.Initalize();
            if (Locomotion != null) Locomotion.LocomotionProxy.Initalize();
            if (SensoryPerception != null) SensoryPerception.SensoryPerceptionProxy.Initalize();
            

        }
        
        public void Update()
        {
			Intention.Update();
        	if (Locomotion != null) Locomotion.LocomotionProxy.Update();
        }

        public void Dispose()
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
