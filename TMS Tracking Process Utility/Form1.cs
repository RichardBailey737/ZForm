using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BBDS.Classes;
using BBDS.Classes.AI;
using TMS_Tracking_Process_Utility.Classes;
using GeomLib;


namespace TMS_Tracking_Process_Utility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Loop = new GameProject.GameLoop();
            Loop.GameLogic += new GameProject.GameLoop.GameLogic_delegate(Loop_GameLogic_handler);
            Loop.RenderScene += new GameProject.GameLoop.RenderScene_delegate(Loop_RenderScene);
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            //this.Disposed += new EventHandler(Form1_Disposed);
            cam = new Camera(pb.Width, pb.Height);
            map = new Map(pb.Width, pb.Height, 10, 100,25);
            //cam.Zoom = 50;
            cam.CameraLocation = new Point(pb.Width / 2, pb.Height / 2);
            pb.Resize += new EventHandler(pb_Resize);
        }



        Camera cam;
        Map map;


        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Loop.Running)
            {
                MessageBox.Show("Please stop the simulation before exiting");
                e.Cancel = true;
                return;
            }

        }

        public delegate void GameLogic_Delegate();

        void GameLogicLoop()
        {
            MessageDispatcher.DisplatchDelayedMessages();
            LCO.ForEach(s => s.Update());
            foreach (var Actor in Globals.Actors.Items)
            {
                Actor.Value.Update();
            }
        }

        void Loop_GameLogic_handler()
        {
            
            //if (Loop != null && Loop.Running && !this.IsDisposed && !this.Disposing) {
                //try
                //{
                    this.Invoke(new GameLogic_Delegate(GameLogicLoop));
                //}
                //catch
                //{
      
                //}
           // }
        }

        Bitmap BufferImage;
        Graphics buffer;
        Point p1, p2;
        Graphics pbg;

        Font drawFont = new Font("Arial", 16);
        SolidBrush drawBrush = new SolidBrush(Color.Black);

        void Loop_RenderScene()
        {
            
            buffer = Graphics.FromImage(BufferImage);
            if (pbg == null) pbg = pb.CreateGraphics();
            buffer.Clear(Color.White);


            p1 = cam.CenterPoint(cam.TranslatePoint(new PointF(0, 0))).ToPoint();
            p2 = cam.CenterPoint(cam.TranslatePoint(new PointF(map.Width, map.Height))).ToPoint();

            buffer.DrawRectangle(new Pen(Brushes.Black), p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
            double scale = (4 * cam.Zoom + 4) / cam.Zoom;

            foreach (var bld in map.Buildings)
            {
                p1 = cam.CenterPoint(cam.TranslatePoint(new Point(bld.PositionRect.X, bld.PositionRect.Y))).ToPoint();
                p2 = cam.CenterPoint(cam.TranslatePoint(new Point(bld.PositionRect.Right, bld.PositionRect.Bottom))).ToPoint();
                buffer.DrawRectangle(new Pen(Brushes.Black), p1.X, p1.Y, (p2.X - p1.X), (p2.Y - p1.Y));
            }

            foreach (var a in Globals.Actors.Items)
            {

                p1 = cam.CenterPoint(cam.TranslatePoint((a.Value.Statistics as Classes.CitizenStats).Location.ToPoint())).ToPoint();
                buffer.FillEllipse(Brushes.Blue, (int)(p1.X - (scale / 2)), (int)(p1.Y - (scale / 2)), (int)(scale), (int)(scale));

            }
            if (GameProject.GameLoop.DeltaTime >0) buffer.DrawString((1000 / GameProject.GameLoop.DeltaTime).ToString(), drawFont, drawBrush, 0, 0);
            
            //foreach (var act in Globals.Actors.Items)
            //{
            //    foreach (var p in (act.Value.Locomotion as CitizenLocomotion).path)
            //    {
            //        buffer.FillEllipse(Brushes.Blue, p.X, p.Y, 2, 2);
            //    }

            //    buffer.DrawString(((act.Value.Locomotion as CitizenLocomotion).pPoint).ToString(), drawFont, drawBrush, 0, 25);
            //}
            pbg.DrawImage(BufferImage, 0, 0);

        }

        public GameProject.GameLoop Loop;
        List<IObjectLifeCycle> LCO = new List<IObjectLifeCycle>();

        #region Form Handlers


        private void newBtn_Click(object sender, EventArgs e)
        {
            map.CitizenNumber = 1;
            map.Init();
            BufferImage = new Bitmap(cam.ViewportWidth, cam.ViewportHeight);
            Loop.Initialize();
            
        }

        private void zoomBtn_Click(object sender, EventArgs e)
        {
            MoveBtn.Checked = false;
            if (zoomBtn.Checked)
                zoomBtn.Checked = false;
            else
                zoomBtn.Checked = true;
        }

        private void MoveBtn_Click(object sender, EventArgs e)
        {
            zoomBtn.Checked = false;
            MoveBtn.Checked = !MoveBtn.Checked;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            cam.Zoom = 100;
            cam.CameraLocation = new Point(pb.Width / 2, pb.Height / 2);
        }

        void pb_Resize(object sender, EventArgs e)
        {
            cam.ViewportHeight = pb.Height;
            cam.ViewportWidth = pb.Width;
        }


        private void pb_Click(object sender, EventArgs e)
        {

            Point p = pb.PointToClient(Control.MousePosition);


            if (zoomBtn.Checked) {
                if (cam != null)  {
                    cam.CameraLocation = cam.RevertPoint(p);
                    if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Right) 
                        cam.Zoom *= 2;
                    else
                        cam.Zoom /= 2;
                }
            } else if (MoveBtn.Checked) {
                cam.CameraLocation = cam.RevertPoint(p);
            //'MsgBox(p.ToString & " " & cam.CameraLocation.ToString)
            //cam.DrawMap(m, pb.CreateGraphics)
            }
        }


        #endregion

        private void stopSimBtn_Click(object sender, EventArgs e)
        {
            Loop.Stop();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Hello?");
        }


    }
}
