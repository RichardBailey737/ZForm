using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace BBDS.Classes.AI
{
    public class ActionPool
    {
        public ActionPool(Behavior Parent)
        {
            this.Parent = Parent;
            pool = new Dictionary<string, Type>();
        }

        public void Initalize() {
            Assembly ass = Assembly.GetCallingAssembly();
            Type[] t = ass.GetTypes();
            foreach (Type thistype in t)
            {
                if (thistype.IsSubclassOf(typeof(ActionBase)) && thistype != typeof(ActionBase))
                {
                    pool.Add(thistype.Name.ToUpper(), thistype);   
                }
                
            }
        }

        Dictionary<String, Type> pool;
        public Behavior Parent { get; private set; }
        public ActionBase GetAction(string ActionName)
        {
            ActionBase rtrn = null;
            if (pool.ContainsKey(ActionName.ToUpper())) {
                rtrn = (ActionBase)Activator.CreateInstance(pool[ActionName.ToUpper()], Parent);
            } else {
                throw new Exception("ActionType not found: " + ActionName);
            }

            return rtrn;
        }

        public T GetAction<T>(string ActionName)
        {
            T rtrn = default(T);
            if (pool.ContainsKey(ActionName.ToUpper()))
            {
                rtrn = (T)Activator.CreateInstance(pool[ActionName.ToUpper()], Parent);
            }
            else
            {
                throw new Exception("ActionType not found: " + ActionName);
            }

            return rtrn;
        }
    }
}
