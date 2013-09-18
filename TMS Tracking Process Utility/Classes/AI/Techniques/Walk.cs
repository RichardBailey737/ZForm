using System;
using UnityEngine;

namespace Techniques {
	
	public class Walk: Technique
	{
		public Walk ()
		{
			this.Description="Moves the player to the clicked position. ";	
			this.ActionName = "Walk";
		}
		
		private Vector3 targetPosition = Vector3.zero;
		public Vector3 TargetPosition { get { return targetPosition;}
			set {
				this.Name = "Walk to position " + value.ToString();
				targetPosition = value;
			} 
		}
		

		
	}
}

