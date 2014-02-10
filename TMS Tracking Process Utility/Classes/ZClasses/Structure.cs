using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;


namespace TMS_Tracking_Process_Utility.Classes
{
    public class Structure
    {
        public Structure(int BuildingID, Map AreaMap) {
            Area = AreaMap;
            this.BuildingID = BuildingID;

            bool validpos = false;
            int counter = 0;

            while (!validpos)
            {
                PositionRect = new System.Drawing.Rectangle(Utilities.R(1, Area.Width - 1), Utilities.R(1, Area.Height - 1), Utilities.R(AreaMap.MinBuildingSize, AreaMap.MaxBuidingSize), Utilities.R(AreaMap.MinBuildingSize, AreaMap.MaxBuidingSize));
                _center = new GeomLib.Point2D(PositionRect.X + PositionRect.Width / 2, PositionRect.Y + PositionRect.Height / 2);
                validpos = !Area.IntersectsBuilding(PositionRect);
                counter += 1;
                if (counter > 50) throw new Exception("Cannot place this building");
            }

            Food = Utilities.R(5, 20);
            if (Utilities.RTFWeighted(AreaMap.GroceryPerc)) Food += Utilities.R(25, 1000);  //5% of stores are grocery stores.  They get extra food

            if (Utilities.RTFWeighted(AreaMap.HasGunPercentage))
            {
                //    'Location has a gun
                Guns = Utilities.R(1, 5);
                Ammo = Utilities.R(10, 100);
            }
            else if (Utilities.RTFWeighted(AreaMap.GunStorePercentage))
            {
                Guns = Utilities.R(AreaMap.GunStoreGunMin, AreaMap.GunStoreGunMax);
                Ammo = Utilities.R(AreaMap.GunStoreAmmoMin, AreaMap.GunStoreAmmoMax);
            }

            Secured = false;
            SecureStrength = 0;
            SecuringMaterials = Utilities.R(1, 50);

    }

        private  GeomLib.Point2D _center;

        [Browsable(true), Category("Building Properties"), Description("Unique identifier for this building")]
        public int BuildingID { get; set; }

        [Browsable(false)] public Map Area { get; set; }
        [Browsable(false)] public System.Drawing.Rectangle PositionRect { get; set; }

        [Browsable(true), Category("Building Properties"), Description("Amount of food contained within")]
        public int Food { get; set; }
        [Browsable(true), Category("Building Properties"), Description("Number of guns inside")]
        public int Guns { get; set; }
        [Browsable(true), Category("Building Properties"), Description("Amount of ammo inside")]
        public int Ammo { get; set; }
        [Browsable(true), Category("Building Properties"), Description("Has this building been secured with securing materials?")]
        public Boolean Secured { get; set; }
        [Browsable(true), Category("Building Properties"), Description("Strenth of secured building (determines how long it will hold up to attack).")]
        public Double SecureStrength { get; set; }
        [Browsable(true), Category("Building Properties"), Description("Amount of securing materials in this building (wood, nails hammer etc)")]
        public int SecuringMaterials { get; set; }

        [Browsable(false)] 
        public GeomLib.Point2D CenterPoint 
        {
            get {
                return _center;
            }
        }

    }
}
