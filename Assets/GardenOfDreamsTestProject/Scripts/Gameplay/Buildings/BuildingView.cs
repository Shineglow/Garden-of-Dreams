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

        public void OnPointerDown(PointerEventData eventData)
        {
            if(CanReceiveEvents)
                PointerDown?.Invoke();
        }
    }
}