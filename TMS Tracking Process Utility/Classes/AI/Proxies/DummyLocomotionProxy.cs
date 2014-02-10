using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes.AI.Proxies
{
    public class DummyLocomotionProxy : ILocomotionProxy
    {
        public void Initalize()
        {
            
        }

        public Actor ParentActor { get; set; }

        public void SetRandomDestination()
        {
            
        }

        public bool GoToTarget(MovementSpeed Speed)
        {
            return true;
        }

        public void SetTarget(Actor TargetActor)
        {
            
        }

        public void SetTarget(float x, float y, float z)
        {
            
        }

        public void GeneratePath()
        {
            
        }

        public void Update()
        {
           
        }
    }
}
