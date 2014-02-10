using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes.AI
{
    /// <summary>
    /// Moves actor to new positions (collision resultion etc)
    /// </summary>
    public class ActorLocomotion : IObjectLifeCycle
    {
        public ActorLocomotion(Actor Parent)
        {
            this.ParentActor = Parent;
        }

        public Actor ParentActor { get; private set; }

        public virtual void Initalize()
        {
            
        }

        public virtual void Update()
        {
           
        }

        public virtual  void Dispose()
        {
            
        }
    }
}
