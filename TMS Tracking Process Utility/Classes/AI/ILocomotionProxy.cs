using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBDS.Classes.AI;

namespace BBDS.Classes
{
    public interface ILocomotionProxy
    {
        void Initalize();
        Actor ParentActor { get; set; }
        void Update();
    }
	public enum MovementSpeed { 
		Sneak = 0,
		Walk = 1,
		Run = 2, 
		Sprint = 3
	}
}
