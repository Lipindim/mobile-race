using System;
using UnityEngine;

namespace Tools
{
    public static class ResourceLoader
    {
        public static Sprite LoadSprite(string path)
        {
            return Resources.Load<Sprite>(path);
        }

        public static GameObject LoadPrefab(string path)
        {
            return Resources.Load<GameObject>(path);
        }

        internal static T LoadObject<T>(string path)
        {
            return Resources.Load<GameObject>(path).GetComponent<T>();
        }
    }
}