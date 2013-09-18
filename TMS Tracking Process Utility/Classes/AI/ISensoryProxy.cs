using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBDS.Classes.AI;

namespace BBDS.Classes
{
    public interface ISensoryProxy
    {
        Actor ParentActor { get; set; }
        List<AI.Actor> CanSee(float VisionDistance);
        void Initalize();
    }
}
