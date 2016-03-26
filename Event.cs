using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater
{
    public class Event
    {
        // Make another place Called Action that contains a reference to the Event and create properties called ID and Timestamp

        public readonly string Name;

        public Event(string name)
        {
            Name = name;
        }
    }
}
