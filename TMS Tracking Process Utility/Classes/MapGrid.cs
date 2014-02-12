using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBDS.Classes.AI;
using System.Drawing;

namespace TMS_Tracking_Process_Utility.Classes
{
    public class MapGrid : IDictionary<System.Drawing.Point, List<Actor>>
    {
        public MapGrid(Map map)
        {
            ParentMap = map;
        }

        Map ParentMap;

        Dictionary<Point, List<Actor>> GridData = new Dictionary<Point, List<Actor>>();

        Point tp;

        /*
         * Thought for how to expand this:
         * Create another list of grid points/delegates
         * Create a "subscribe" function that takes a callback delegate and stores it 
         *  under teh point set
         * When MOVE is called, trigger the delegate.
         */
        
        public void Add(System.Drawing.Point key, List<Actor> value)
        {
            GridData[key] = value;
        }

        public void Add(System.Drawing.Point pt, Actor actor)
        {
            if (!GridData.ContainsKey(pt))
            {
                GridData[pt] = new List<Actor>();
            }
            if (!GridData[pt].Contains(actor))  GridData[pt].Add(actor);
        }

        public void Add(int x, int y, Actor actor)
        {
            tp = new Point(x, y);
            Add(tp, actor);
        }

        public void Move(Point moveFrom, Point moveTo, Actor actor)
        {
            Remove(moveFrom, actor);
            Add(moveTo, actor);
        }

        public void Remove(Point pt, Actor actor)
        {
            if (GridData.ContainsKey(pt))
            {
                GridData[pt].Remove(actor);
            }
        }

        public void Remove(int x, int y, Actor actor)
        {
            tp = new Point(x, y);
            Remove(tp, actor);
        }

        /// <summary>
        /// Returns all the gridpoints within the visual range of the origin
        /// </summary>
        /// <param name="ViewRange"></param>
        /// <param name="Origin"></param>
        /// <returns></returns>
        public List<Actor> ActorsInRange(int ViewRange, Point Origin)
        {
            List<Actor> rtrn = new List<Actor>();
            int range = (int)(Math.Floor(ViewRange/ParentMap.GridSize));
            for (int x = Origin.X - range; x <= Origin.X + range; x++)
            {
                for (int y = Origin.Y - range; y <= Origin.Y + range; y++)
                {
                    rtrn.AddRange(this[x, y]);
                }
                
            }

            return rtrn;
        }

        public bool ContainsKey(System.Drawing.Point key)
        {
            return (GridData.ContainsKey(key));
        }

        public ICollection<System.Drawing.Point> Keys
        {
            get { return GridData.Keys; }
        }

        public bool Remove(System.Drawing.Point key)
        {
            return GridData.Remove(key);
        }

        public bool TryGetValue(System.Drawing.Point key, out List<Actor> value)
        {
            throw new NotImplementedException();
        }

        public ICollection<List<Actor>> Values
        {
            get { return GridData.Values; }
        }

        public List<Actor> this[System.Drawing.Point key]
        {
            get
            {
                tp = new Point(x, y);
                if (GridData.ContainsKey(tp))
                    return GridData[tp];
                else
                    return null;
            }
            private set
            {
                GridData[key] = value;
            }
        }

        public List<Actor> this[int x, int y]
        {
            get
            {
                tp = new Point(x, y);
                if (GridData.ContainsKey(tp))
                    return GridData[tp];
                else
                    return null;
            }
            private set
            {
                 GridData[new Point(x, y)] = value;
            }
        }

        private void Add(KeyValuePair<System.Drawing.Point, List<Actor>> item)
        {
            GridData.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<System.Drawing.Point, List<Actor>> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<System.Drawing.Point, List<Actor>>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return GridData.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<System.Drawing.Point, List<Actor>> item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<System.Drawing.Point, List<Actor>>> GetEnumerator()
        {
            return GridData.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GridData.GetEnumerator();
        }
    }
}
