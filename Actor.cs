using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Theater
{
    public class Actor
    {
        public delegate void BindOne(string key, bool persist, Action<dynamic> action);
        public delegate void BindAny(Action<dynamic> action, bool persist, params string[] keys);

        public BufferBlock<Event> Action = new BufferBlock<Event>();
        public string Act;

        // This should be set with DI
        public Func<string, string[]> Direction = (key) =>
        {
            return new string[] { };
        };

        public Action<Action<Event>, BindOne, BindAny, Script, Action<string, dynamic>, Action<string, Action<dynamic>>> Execution;

        public Setting Setting;

        public Script Script;
        
        public void Cue()
        {
            this.Execution(Claim, Setting.Bind, Setting.Bind, Script, Setting.RegisterSource,

                (question, action) =>
                {
                    Setting.Bind(action, false, Direction(question));
                }
            );
        }

        private void Claim(Event claim)
        {
            Action.Post(claim);
        }
    }
}