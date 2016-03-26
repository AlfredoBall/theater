using System;
using System.Collections.Generic;
using System.Linq;

namespace Theater
{
    public class Act
    {
        private List<Scene> Scenes = new List<Scene>();

        public List<Scene> this[string[] keys]
        {
            get
            {
                return Scenes.Where(scene => scene.Keys.Any(k1 => keys.Any(k2 => k1 == k2))).ToList();
            }
        }

        public void Add(Scene scene)
        {
            Scenes.Add(scene);
        }

        public void Remove(string key)
        {
            var scenes = Scenes.Where(scene => scene.Keys.Any(k => k == key) && !scene.Persist).ToList();
            Scenes.RemoveAll(scene => scene.Keys.Any(k => k == key) && !scene.Persist);
        }

        public bool ContainsKey(string[] keys)
        {
            return keys.ToList().Any(key =>
            {
                return Scenes.Any(scene => scene.Keys.Any(k => k == key));
            });
        }
    }
}
