using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBDS.Classes.AI;

namespace BBDS.Classes
{
    public interface IBodyProxy
    {
        Actor ParentActor { get; set; }

        void Initalize();
        void SetBody(string BodyName);
    }
}
