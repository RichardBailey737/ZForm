using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes.AI.Actors
{
    public class HumanActor : Actor
    {
        public HumanActor(IBodyProxy BodyProxyClass, ILocomotionProxy LocomotionProxyClass, ISensoryProxy SensoryProxyClass)
            : base(BodyProxyClass, LocomotionProxyClass, SensoryProxyClass)
        {

        }
		
		public HumanActor() : base (){
		}

        public override void Initalize()
        {
            base.Initalize();
            //this.Body.SetBody("human");
            this.Intention[0].ChangeTo(new ActionTransition { ToAction = "ProcessQueue", Reason = "Inital state" });
            this.Statistics.Speed = 10;
            this.Statistics.VisionDistance = 15;
            this.Statistics.Mass = 68;
            //this.Statistics.Mass = 10;

            
        }
        
    }
}
