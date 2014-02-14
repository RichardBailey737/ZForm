using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBDS.Classes;
using BBDS.Classes.AI;
using GeomLib;
using System.Drawing;
using Algorithms;


namespace TMS_Tracking_Process_Utility.Classes
{
    public class CitizenLocomotion : ActorLocomotion
    {
        public CitizenLocomotion(Actor Parent, Map map) : base(Parent)
        {
            Area = map;
        }

        public override void Initalize()
        {
            base.Initalize();
        }
        
        public List<PathFinderNode> path;
        Map Area;
        public double TimeToTarget { get; private set; }
        private CitizenStats Stats { get { return (CitizenStats)ParentActor.Statistics; } }
        long Starttime = 0;

        public double elapsedtime;
        public double pPoint;
        public Rectangle CurrentPointBounds;
        Point CurrentGridPoint;
        Point PreviousGridPoint;

        public override void Update()
        {
            base.Update();
            if (path != null) {
                elapsedtime = GameProject.GameLoop.GameTime - Starttime;
                pPoint = elapsedtime * Stats.MovementSpeed / 2000;
                int pathpoint = (int)Math.Round(elapsedtime * Stats.MovementSpeed/2000);
                if (pathpoint >= 0 & pathpoint < path.Count)
                {
                    Stats.Location.X = path[pathpoint].X;
                    Stats.Location.Y = path[pathpoint].Y;
                    if (CurrentPointBounds == null || !CurrentPointBounds.Contains(Stats.Location.ToPoint()))
                    {
                        PreviousGridPoint = CurrentGridPoint;
                        CurrentGridPoint = new Point((int)Math.Ceiling(Stats.Location.X / Area.GridSize), (int)Math.Ceiling(Stats.Location.Y / Area.GridSize));
                        CurrentPointBounds = new Rectangle(CurrentGridPoint.X, CurrentGridPoint.Y, (int)Area.GridSize, (int)Area.GridSize);
                        Area.Grid.Move(PreviousGridPoint, CurrentGridPoint, this.ParentActor);
                    }
                    if (pathpoint == path.Count - 1) path = null;
                }
                else if (pathpoint > path.Count)
                {
                    path = null;
                }
            }
        }

        public bool Moving()
        {
            return path != null;
        }

         public void GeneratePath(Point PointToMoveTo) {
             PathFinderFast p = new PathFinderFast(Area.PathGrid);
            p.Diagonals = true;
            p.Formula = Algorithms.HeuristicFormula.Manhattan;
            p.HeavyDiagonals = false;
            p.HeuristicEstimate = 2;
            p.PunishChangeDirection = false;
            p.TieBreaker = false;
            p.SearchLimit = 50000;
            Starttime = GameProject.GameLoop.GameTime;
    
             try 
	        {	        
		        path = p.FindPath(Stats.Location.ToPoint(), PointToMoveTo);
	        }
	        catch (Exception ex)
	        {
                throw new Exception("Error generating path for citizen " + ParentActor.ID.ToString() + ".  Moving from point " + Stats.Location.X + "," + Stats.Location.Y + " to " + PointToMoveTo.X + "," + PointToMoveTo.Y + " in area " + Area.Width + "," + Area.Height, ex);
	        }


             if (path != null)
             {
                 double Rate = Stats.MovementSpeed;
                 TimeToTarget = (path.Count - 1) / Rate;
                 Starttime = GameProject.GameLoop.GameTime;
             }
             else
             {
                 Console.WriteLine("Could not find a path for citizen " + ParentActor.ID.ToString());
             }
         }

         public void GenerateRandomPath()
         {
            Point p = new Point();
            p.X = Utilities.R(1, Area.Width);
            p.Y = Utilities.R(1, Area.Height);
            GeneratePath(p);
         }

    }
}
