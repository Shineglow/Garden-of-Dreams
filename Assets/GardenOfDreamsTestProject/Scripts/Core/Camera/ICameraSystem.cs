using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Core.Camera
{
    public interface ICameraSystem
    {
        Vector3 ViewportToWorldPoint(Vector3 pos);
    }
}