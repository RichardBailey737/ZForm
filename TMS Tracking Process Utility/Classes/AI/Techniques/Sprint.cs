using System;
using UnityEngine;

namespace Techniques {
	
	public class Sprint: Technique
	{
		public Sprint ()
		{
			this.Description="Moves the player to the clicked position as fast as possible.  Creates lots of attention.";	
			this.ActionName = "Sprint";
		}
		
		private Vector3 targetPosition = Vector3.zero;
		public Vector3 TargetPosition { get { return targetPosition;}
			set {
				this.Name = "Sprint to position " + value.ToString();
				targetPosition = value;
			} 
		}
		

		
	}
}

