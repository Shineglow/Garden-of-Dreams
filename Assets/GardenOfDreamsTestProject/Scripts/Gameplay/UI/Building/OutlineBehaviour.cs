using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.UI.Building
{
    public class OutlineBehaviour : MonoBehaviour
    {
        public void MoveToSelected(RectTransform go)
        {
            transform.position = go.position;
        }
    }
}