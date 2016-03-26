using System;
using System.Collections.Generic;
using System.Linq;

namespace Theater
{
    public class Setting
    {
        public Dictionary<string, object> Sources = new Dictionary<string, object>();

        public Act Act = new Act();

        public void RegisterSource(string key, object value)
        {
            Sources[key] = value;
            var keys = new string[] { key };

            if (Act.ContainsKey(keys))
            {
                CallActions(keys);
            }
        }

        // Actors should be able to set a binding that perists and one that doesn't
        
        public void Bind(Action<dynamic> action, bool persist, string[] keys)
        {
            Act.Add(new Scene(keys, action, persist));

            if (keys.Any(key => Sources.ContainsKey(key)))
            {
                CallActions(keys);
            }
        }

        public void Bind(string key, bool persist, Action<dynamic> action)
        {
            var keys = new string[] { key };
            Act.Add(new Scene(keys, action, persist));

            if (Sources.ContainsKey(key))
            {
                CallActions(keys);
            }
        }

        public void CallActions(string[] keys)
        {
            List<Action> actions = new List<Action>();

            Act[keys].ForEach(scene =>
            {
                var value = new System.Dynamic.ExpandoObject() as IDictionary<string, Object>;

                scene.Keys.ToList().ForEach(key =>
                {
                    value.Add(key, Sources.ContainsKey(key) ? Sources[key] : null);
                });

                actions.Add(() => { scene.Action(value); });
            });

            keys.ToList().ForEach(key =>
            {
                Sources.Remove(key);
                Act.Remove(key);
            });

            actions.ForEach(action => action());
        }
    }
}
