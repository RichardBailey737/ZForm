using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace GameProject
{
    public class GameTimer
    {
        [DllImport("kernel32.dll")]
        private static extern long GetTickCount();

        private long StartTick = 0;

        public GameTimer()
        {
            Reset();
        }

        public void Reset()
        {
            StartTick = GetTickCount();
        }

        public long GetTicks()
        {
            long currentTick = 0;
            currentTick = GetTickCount();

            return currentTick - StartTick;
        }

    }
}
