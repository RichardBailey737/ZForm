using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes.AI.Proxies
{
    public class DummySensoryProxy : ISensoryProxy
    {
        public Actor ParentActor { get; set; }

        public List<Actor> CanSee(float VisionDistance)
        {
            return Globals.Actors.Items.Values.ToList();
        }

        public void Initalize()
        {
            
        }
    }
}
