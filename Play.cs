using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace Theater
{
    public static class Play
    {
        // TODO Setup a constructor that accepts providers

        public static BufferBlock<Event> Performance = new BufferBlock<Event>();

        public static Script Script;

        public static List<Actor> Cast;

        public static Setting Setting;

        public static void Action()
        {
            Cast.ForEach(actor =>
                {
                    actor.Setting = Setting;
                    actor.Script = Script;
                    actor.Action.LinkTo(Performance, Script.Plot);
                    actor.Cue();
                });
        }
    }
}
