using System;
using GardenOfDreamsTestProject.Scripts.Configuration.Grid;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Grid
{
    public class GridView : MonoBehaviour, IGridView, IPointerMoveHandler
    {
        public Transform Transform => transform;
        
        [SerializeField] private SpriteRenderer _background;
        private Vector2Int _size;
        [SerializeField] private Color darkGreen = new(0.1f,0.3f,0.1f);
        [SerializeField] private Color lightGreen = new(0.1f,0.6f,0.1f);
        
        public event Action PointerMoveUnderGameObject;

        private void Awake()
        {
            Initialize(new Vector2Int(20,20), 0.5f);
        }

        public void Initialize(Vector2Int size, float unitsPerCell)
        {
            _size = size;

            var texture = GetNewTexture2D(_size.x, _size.y);

            Rect rect = new Rect(Vector2.zero, _size);
            var backgroundSprite = Sprite.Create(texture, rect, Vector2.one * 0.5f, Convert.ToInt32(1/unitsPerCell));
            _background.sprite = backgroundSprite;

            var colliderComponent = _background.GetComponent<BoxCollider2D>();
            colliderComponent.size = unitsPerCell * (Vector2)_size;
        }

        private Texture2D GetNewTexture2D(int width, int height)
        {
            Texture2D texture = new Texture2D(width, height, TextureFormat.RGBA32, false);
            for (int y = 0; y < height; y += 4)
            {
                for (int x = 0; x < width; x++)
                {
                    texture.SetPixel(x, y, darkGreen);
                    if (y + 1 < height)
                        texture.SetPixel(x, y + 1, lightGreen);
                    if (y + 2 < height)
                        texture.SetPixel(x, y + 2, darkGreen);
                    if (y + 3 < height)
                        texture.SetPixel(x, y + 3, lightGreen);
                    (lightGreen, darkGreen) = (darkGreen, lightGreen);
                }
            }

            texture.filterMode = FilterMode.Point;
            texture.Apply();
            return texture;
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            PointerMoveUnderGameObject?.Invoke();
        }
    }
}
