using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBDS.Classes.AI.Actions.Human
{
    public class ProcessQueue : ActionBase
    {
        public ProcessQueue(Behavior Parent)
            : base(Parent)
        {

        }
		
		Technique CurrentTechnique = null;
		ActionTransition Transition = new ActionTransition();
		
        public override ActionTransition Start(ActionTransition PreviousAction)
        {
			Transition.FromAction = this;
            return null;
        }
		
        public override ActionTransition Update()
        {
			if (GameData.TechniqueQueue.Count > 0) {
				CurrentTechnique = GameData.TechniqueQueue[0];
				GameData.TechniqueQueue.RemoveAt(0);
				Transition.Reason = "Processing next item in the queue";
				Transition.ToAction	= CurrentTechnique.ActionName;
				Transition.Data = CurrentTechnique;				
				return Transition;
				
			} else Globals.isPaused = true;
            return base.Update();
        }
    }
}
