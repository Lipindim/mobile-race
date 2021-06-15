using UnityEngine;


namespace Tools
{
    public interface ICameraTool
    {
        Vector3 ScreenToWorldPoint(Vector3 position);
    }
}
