using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMS_Tracking_Process_Utility
{
    public static class Utilities
    {
        private static Random Rnd = new Random();

        public static int Random1to10() {
            return R(1, 10);
        }

        public static int Random1to10Weighted(int Percentage) {
            int i  = R(1, 5);
            if (R(0, 100) < Percentage) i = i + R(0, 5);
            return i;
        }

        public static int R(int StartNumber , int EndNumber) {
            return Rnd.Next(StartNumber, EndNumber + 1);
        }

        public static bool RTF() {
            return (R(0, 100) < 50);
        }

        public static bool RTFWeighted(int PercentageForTrue) {
            return (R(1, 100) < PercentageForTrue);
        }

      
    }
}
