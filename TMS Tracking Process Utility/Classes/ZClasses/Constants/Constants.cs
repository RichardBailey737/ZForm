using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMS_Tracking_Process_Utility.Classes.Constants
{
    public static class Actions
    {
        public static string MoveRandomly = "MoveRandomly";
        public static string Walk = "Walk";
    }

    public static class Messages
    {
        public static const int SoundHeard = 0;
        public static const int ActorSeen = 1;
        public static const int ActorNoLongerSeen = 2;
    }
}

