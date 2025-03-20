using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Core.Camera
{
    [RequireComponent(typeof(CameraSystem))]
    public class CameraSystem : MonoBehaviour, ICameraSystem
    {
        private UnityEngine.Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<UnityEngine.Camera>();
        }

        public Vector3 ViewportToWorldPoint(Vector3 pos)
        {
            return _camera.ViewportToWorldPoint(pos);
        }
    }
}