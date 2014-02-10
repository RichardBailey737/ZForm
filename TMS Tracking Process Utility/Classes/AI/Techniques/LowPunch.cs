using System;

namespace Techniques {
	
	public class LowPunch: Technique
	{
		public LowPunch ()
		{
			this.Description="A punch to the stomach or whatever is in reach.  Builds momentum and can add surprise when used properly. ";	
			this.ActionName = "LowPunch";
		}
		
		private int targetID;
		public int TargetID { get { return targetID;}
			set {
				this.Name = "Low punch " + BBDS.Classes.Globals.Actors[value].Statistics.OtherStats["NAME"].ToString();
				targetID = value;
				
			} 
		}
		
		
		
	}
}

