using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;


namespace GameProject
{
    public class GameLoop
    {

        BackgroundWorker LoopWorker;
        private bool isRunning = false;
        GameTimer timer = new GameTimer();
        private static GameLoop _instance;

        long gameTime = 0;
        long _delta = 0;
        public static long GameTime
        {
            get
            {
                return GameLoop._instance.gameTime;
            }
        }

        public static long DeltaTime
        {
            get
            {
                return GameLoop._instance._delta;
            }
        }

        public bool Running
        {
            get { return LoopWorker.IsBusy; }
        }


        public GameLoop()
        {
            LoopWorker = new BackgroundWorker();
            LoopWorker.WorkerSupportsCancellation = true;
            LoopWorker.DoWork += new DoWorkEventHandler(GameLoop_DoWork);
            GameLoop._instance = this;
        }

        public void Initialize()
        {
            LoopWorker.RunWorkerAsync();
            isRunning = true;
        }

        public void Stop()
        {
            LoopWorker.CancelAsync();
        }

        public delegate void GameLogic_delegate();
        public delegate void RenderScene_delegate();


        public event GameLogic_delegate GameLogic;
        public event RenderScene_delegate RenderScene;


        void GameLoop_DoWork(object sender, DoWorkEventArgs e)
        {
           
            while (isRunning)
            {
   
                timer.Reset();
                if (GameLogic != null) GameLogic();
                if (RenderScene != null) RenderScene();
                while (timer.GetTicks() < 50)
                {
                    if (this.LoopWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        isRunning = false;
                        return;
                    }
                }
                _delta = timer.GetTicks();
                gameTime += _delta;
            }

        }


        //Timer timer = new Timer();

        //public Form1()
        //{
        //    InitializeComponent();

        //}

        //public void GameLoop()
        //{
        //    while (this.Created)
        //    {
        //        timer.Reset();
        //        GameLogic();
        //        RenderScene();
        //        Application.DoEvents();
        //        while (timer.GetTicks() < 50) ;
        //    }
        //}

        //private void RenderScene()
        //{
        //    // TODO: Add code for rendering your scene here
        //}

        //private void GameLogic()
        //{
        //    // TODO: Add code for your game logic here
        //}


    }
}
