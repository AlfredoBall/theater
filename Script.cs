using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater
{
    public class Script : Dictionary<string, Event>
    {
        public Predicate<Event> Plot;
    }
}