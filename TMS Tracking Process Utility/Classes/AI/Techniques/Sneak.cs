using System;
using UnityEngine;

namespace Techniques {
	
	public class Sneak: Technique
	{
		public Sneak ()
		{
			this.Description="Steathily moves the player to the clicked position.";	
			this.ActionName = "Sneak";
		}
		
		private Vector3 targetPosition = Vector3.zero;
		public Vector3 TargetPosition { get { return targetPosition;}
			set {
				this.Name = "Sneak to position " + value.ToString();
				targetPosition = value;
			} 
		}
		

		
	}
}

