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
        void SetRandomDestination();
        //Vector3 Seek(float Speed);
        //void Flee(float Speed);
        bool GoToTarget(MovementSpeed Speed);
		
        void SetTarget(Actor TargetActor);
		void SetTarget(float x, float y, float z);
		void GeneratePath(); 
        void Update();
    }
	public enum MovementSpeed { 
		Sneak = 0,
		Walk = 1,
		Run = 2, 
		Sprint = 3
	}
}
