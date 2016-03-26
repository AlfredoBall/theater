using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater
{
    public class Scene
    {
        public readonly string[] Keys;
        public readonly Action<dynamic> Action;
        public readonly bool Persist;

        public Scene(string[] keys, Action<dynamic> action, bool persist)
        {
            Keys = keys;
            Action = action;
            Persist = persist;
        }
    }
}
