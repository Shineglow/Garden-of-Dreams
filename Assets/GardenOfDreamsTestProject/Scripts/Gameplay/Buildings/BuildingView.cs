using System;
using GardenOfDreamsTestProject.Scripts.Core.EventSystemEntities;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Buildings
{
    public class BuildingView : MonoBehaviour, IBuildingView, IPointerDownEventHandler
    {
        public string Name => name;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Material normalMaterial;
        [SerializeField] private Material shadowMaterial;
        

        private bool _isShadowModeEnabled;
        public bool IsShadowModeEnabled
        {
            get => _isShadowModeEnabled;
            set
            {
                if(_isShadowModeEnabled == value)
                    return;
                _isShadowModeEnabled = value;
                _spriteRenderer.material = value ? shadowMaterial : normalMaterial;
            }
        }

        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public bool CanReceiveEvents { get; set; }
        public event Action PointerDown;

        private void Awake()
        {
            if (_spriteRenderer == null)
                throw new NullReferenceException(
                    $"{nameof(_spriteRenderer)} field not initialized!");
        }

        public void SetView(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }

        public void SetColor(Color shadowColorValue)
        {
            _spriteRenderer.color = shadowColorValue;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if(CanReceiveEvents)
                PointerDown?.Invoke();
        }
    }
}