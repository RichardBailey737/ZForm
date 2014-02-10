using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMS_Tracking_Process_Utility.Classes
{
    public class UndeadStats : BBDS.Classes.AI.ActorStatistics
    {
        private int _movementSpeed;
        public int Strength { get; set; }
        public int Speed { get; set; }
        public int MovementSpeed {
            get
            {
                return Math.Min(_movementSpeed, Health); //If he's fast, he slows down as he gets hurt.
            }
            set { 
                _movementSpeed = value; 
            }
        }
        public int Health { get; set; }

    }
}
