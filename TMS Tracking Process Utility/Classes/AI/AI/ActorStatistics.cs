using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes.AI
{
    /// <summary>
    /// Actors basic attributes.  Intelligence, strength etc.
    /// Override for custom class attributes.
    /// </summary>
    public class ActorStatistics
    {

        //public int Speed { get; set; }
        //public float VisionDistance { get; set; }
        //public float TurnRate { get; set; }
        //public float Mass { get; set; }
		
		public Dictionary<string, object> OtherStats = new Dictionary<string, object>();
        
    }
}
