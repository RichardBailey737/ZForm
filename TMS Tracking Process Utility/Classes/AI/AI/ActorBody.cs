using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes.AI
{
    /// <summary>
    /// Owns animation state
    /// </summary>
    public class ActorBody
    {
        public ActorBody(Actor Parent, IBodyProxy Proxy)
        {
            this.BodyProxy = Proxy;
            this.ParentActor = Parent;
        }

        public IBodyProxy BodyProxy { get; private set; }
        public Actor ParentActor { get; private set; }

        public void SetBody(string BodyName)
        {
            BodyProxy.SetBody(BodyName);
        }
    }
}
