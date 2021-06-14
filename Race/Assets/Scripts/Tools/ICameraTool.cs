using UnityEngine;


namespace Tools
{
    internal interface ICameraTool
    {
        public Vector3 ScreenToWorldPoint(Vector3 position);
    }
}
