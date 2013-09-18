using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes.AI
{
    /// <summary>
    /// Moves actor to new positions (collision resultion etc)
    /// </summary>
    public class ActorLocomotion
    {
        public ActorLocomotion(Actor Parent, ILocomotionProxy Proxy)
        {
            this.ParentActor = Parent;
            this.LocomotionProxy = Proxy;
        }

        public ILocomotionProxy LocomotionProxy { get; private set; }

        public Actor ParentActor { get; private set; }
    }
}
