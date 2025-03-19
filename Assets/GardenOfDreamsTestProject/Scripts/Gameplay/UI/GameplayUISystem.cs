using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.UI
{
    [RequireComponent(typeof(Canvas))]
    public class GameplayUISystem : MonoBehaviour
    {
        private Canvas _canvas;

        [SerializeField] private RectTransform[] layers;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
        }

        public void SetParentOfLayer(RectTransform rectTransform, EGameplayUILayers layer)
        {
            rectTransform.SetParent(layers[(int)layer]);
        }
    }
}
