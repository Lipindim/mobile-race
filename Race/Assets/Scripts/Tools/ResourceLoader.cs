using UnityEngine;

namespace Tools
{
    internal static class ResourceLoader
    {
        public static Sprite LoadSprite(string path)
        {
            return Resources.Load<Sprite>(path);
        }

        public static GameObject LoadPrefab(string path)
        {
            return Resources.Load<GameObject>(path);
        }
    }
}