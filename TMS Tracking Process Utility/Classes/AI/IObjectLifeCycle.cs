using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes
{
    public interface IObjectLifeCycle
    {
        void Initalize();
        void Update();
        void Dispose();


    }
}
