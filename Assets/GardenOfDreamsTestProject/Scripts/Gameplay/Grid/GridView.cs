using System;
using GardenOfDreamsTestProject.Scripts.Configuration.Grid;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Grid
{
    public class GridView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _background;
        private IGridConfiguration _gridConfiguration;
        private Vector2Int _size;

        private void Awake()
        {
            Initialize(new GridConfiguration());
        }

        public void Initialize(IGridConfiguration gridConfiguration)
        {
            _gridConfiguration = gridConfiguration;
            _size = _gridConfiguration.Size;
            
            Texture2D texture = new Texture2D(_size.x, _size.y, TextureFormat.RGBA32, false);
            Color darkGreen = new Color(0.1f,0.3f,0.1f);
            Color lightGreen = new Color(0.1f,0.6f,0.1f);
            for (int y = 0; y < _size.y; y+=4)
            {
                for (int x = 0; x < _size.x; x++)
                {
                    texture.SetPixel(x,y, darkGreen);
                    if (y + 1 < _size.y)
                        texture.SetPixel(x, y + 1, lightGreen);
                    if (y + 2 < _size.y)
                        texture.SetPixel(x, y + 2, darkGreen);
                    if (y + 3 < _size.y)
                        texture.SetPixel(x, y + 3, lightGreen);
                    (lightGreen, darkGreen) = (darkGreen, lightGreen);
                }
            }

            texture.filterMode = FilterMode.Point;
            texture.Apply();
            Rect rect = new Rect(Vector2.zero, _size);
            var backgroundSprite = Sprite.Create(texture, rect, Vector2.one * 0.5f, 2);
            _background.sprite = backgroundSprite;
        }
    }
}
