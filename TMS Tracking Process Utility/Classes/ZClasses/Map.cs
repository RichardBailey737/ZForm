using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace TMS_Tracking_Process_Utility.Classes
{
    public class Map
    {
        public Map(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
            Defaults();
        }

        public Map(int Width , int Height , int BuildingNumber , int CitizenNumber , int ZombiePerc) {
            this.BuildingNumber = BuildingNumber;
            this.CitizenNumber = CitizenNumber;
            this.Width = Width;
            this.Height = Height;
            this.ZombiePercentage = ZombiePerc;
            Defaults();
        }

        private void Defaults()
        {
            MaxBuidingSize = 50;
            MinBuildingSize = 15;
        }
        
        [Browsable(true), Description("The maximum height/width of a building."), Category("Generation Details")]
        public int MaxBuidingSize { get; set; }
        [Browsable(true), Description("Minimum height/width of a building"), Category("Generation Details")]
        public int MinBuildingSize { get; set; }
        [Browsable(true), Description("Percentage of buildings that are grocery stores"), Category("Generation Details")]
        public int GroceryPerc { get; set; }
        [Browsable(true), Description("Percentage of people with guns by default"), Category("Generation Details")]
        public int HasGunPercentage { get; set; }
        [Browsable(true), Description("Percentage of buildings that are gun stores"), Category("Generation Details")]
        public int GunStorePercentage { get; set; }
        [Browsable(true), Description("Minimum number of guns in a gun store"), Category("Generation Details")]
        public int GunStoreGunMin { get; set; }
        [Browsable(true), Description("Maximum number of guns in a gun store"), Category("Generation Details")]
        public int GunStoreGunMax { get; set; }
        [Browsable(true), Description("Minimum ammo in a gun store"), Category("Generation Details")]
        public int GunStoreAmmoMin { get; set; }
        [Browsable(true), Description("Maximum ammo in a gun store"), Category("Generation Details")]
        public int GunStoreAmmoMax { get; set; }
        [Browsable(true), Description("Distance humans and zombies can see.  (Taking into account visual obstructions like trees/cars etc)"), Category("Simulation Details")]
        public int VisualRange { get; set; }
        [Browsable(true), Description("Range that humans and zombies can hear. (Loud actions are more likely to be heard.  This is simply the upper limit on range)"), Category("Simulation Details")]
        public int HearingRange { get; set; }
        [Browsable(true), Description("Percentage of people who are zombies (low populations need a higher percentage for this to work properly)."), Category("Simulation Details")]
        public int ZombiePercentage { get; set; }

        [Browsable(true), Description("Number of buildings to generate"), Category("Simulation Size")]
        public int BuildingNumber { get; set; }
        [Browsable(true), Description("Total number of people to generate (including zombies)"), Category("Simulation Size")]
        public int CitizenNumber { get; set; }

        [Browsable(true), Description("Width of the map.  Defaults to fit in the windows."), Category("Simulation Size")]
        public int Width { get; set; }
        [Browsable(true), Description("Height of the map.  Defualts to fit in the window."), Category("Simulation Size")]
        public int Height { get; set; }
    
        public System.Drawing.Rectangle AreaRect;
        public Byte[,] PathGrid;

        //Public Buildings As List(Of Building)
        [Browsable(false)] 
        public int Time { get; set; }

        [Browsable(false)]
        public int Day { get; set; }

        public List<Structure> Buildings = new List<Structure>();
        public List<BBDS.Classes.AI.Actor> Citizens = new List<BBDS.Classes.AI.Actor>();

        public void Init()
        {

            //Set the pathfinding data
            int gwidth = Width;
            int gheight = Height;
            if ((int)(Math.Log(Width, 2)) != Math.Log(Width, 2))  gwidth = (int)Math.Pow(2, Math.Ceiling(Math.Log(Width, 2)));
            if ( (int)(Math.Log(Height, 2)) != Math.Log(Height, 2))  gheight =(int)Math.Pow(2, Math.Ceiling(Math.Log(Height, 2)));
            PathGrid = new byte[gwidth , gheight ];
            for (Int16 x = 0; x < Width ; x++) {
                for (Int16 y = 0; y < Height; y++) {
                    PathGrid[x, y] = 1;
                }
            }

            AreaRect = new Rectangle(0, 0, Width, Height);
            Buildings = new List<Structure>();

            //Generate building and set the path data
            for (int  t = 1; t <= BuildingNumber; t++) {
                Buildings.Add(new Structure(BBDS.Classes.Globals.GenerateID(), this));
                for (int x = this.Buildings[t - 1].PositionRect.X; x <= Buildings[t - 1].PositionRect.Width + Buildings[t - 1].PositionRect.X; x++) {
                    PathGrid[x, Buildings[t - 1].PositionRect.Y] = 100;
                    PathGrid[x, Buildings[t - 1].PositionRect.Y + Buildings[t - 1].PositionRect.Height] = 100;
                }
                for (int y = Buildings[t - 1].PositionRect.Y; y <= Buildings[t - 1].PositionRect.Y + Buildings[t - 1].PositionRect.Height; y++) {
                    PathGrid[Buildings[t - 1].PositionRect.X, y] = 100;
                    PathGrid[Buildings[t - 1].PositionRect.X + Buildings[t - 1].PositionRect.Width, y] = 100;
                }
            }

            for (int i = 1; i <= CitizenNumber; i++)
            {
                HumanCitizen c = new HumanCitizen(this);
  
                (c.Statistics as CitizenStats).Location = new GeomLib.Point2D(Utilities.R(1, Width), Utilities.R(1, Height));
                c.Initalize();
                Citizens.Add(c);
                
            }


        }

        public Structure InBuilding(System.Drawing.Point Pt) {
            foreach (var bld in Buildings)
	        {
		            if (bld.PositionRect.Contains(Pt)) return bld;
	        }
            return null;
        }


        public bool IntersectsBuilding(System.Drawing.Rectangle rect) {
            foreach (var bld in Buildings)
	            {
                            if (rect.IntersectsWith(bld.PositionRect)) return true;
		 
	            }
            if (rect.X + rect.Width > Width || rect.Y + rect.Height > Height)
                return true;
            else
                return false;
        }
    

    }
}
