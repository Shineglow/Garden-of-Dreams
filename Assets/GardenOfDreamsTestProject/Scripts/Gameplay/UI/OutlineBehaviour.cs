using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.UI
{
    public class OutlineBehaviour : MonoBehaviour
    {
        public void MoveToSelected(GameObject go)
        {
            transform.position = go.transform.position;
        }
    }
}