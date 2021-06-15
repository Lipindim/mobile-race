using UnityEngine;


namespace Tools
{
    public class CameraTool : ICameraTool
    {
        private readonly Camera _camera;

        public CameraTool(Camera camera)
        {
            _camera = camera;
        }

        public Vector3 ScreenToWorldPoint(Vector3 position)
        {
            return _camera.ScreenToWorldPoint(position);
        }
    }
}
