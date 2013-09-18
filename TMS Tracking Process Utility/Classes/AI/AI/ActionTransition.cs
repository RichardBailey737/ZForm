using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes.AI
{
    public class ActionTransition
    {
		

		
        public ActionBase FromAction { get; set; }
        public string ToAction { get; set; }
        public string Reason { get; set; }
        public TransitionType Transition { get; set; }
        public object Data { get; set; }
    }

    public enum TransitionType
    {
        Change = 1,
        Suspend = 2, 
        Resume = 3,
        End = 4
    }
}
