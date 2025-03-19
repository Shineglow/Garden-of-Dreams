using System.Collections.Generic;
using GardenOfDreamsTestProject.Scripts.Configuration.Grid;
using GardenOfDreamsTestProject.Scripts.Core.Extensions;
using GardenOfDreamsTestProject.Scripts.Serialization;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Grid
{
    public class GridSystem : IGridSystem, ISerializeable<GridSystemPD>
    {
        private List<IGridViewObject> _gridViewsOrdered;
        private IGridView _gridView;
        private IGridConfiguration _gridConfiguration;

        public float UnitsPerCell { get; private set; }
        public Vector2Int GridSize { get; private set; }

        public void Initialize(IGridConfiguration gridConfiguration, IGridView gridView)
        {
            _gridConfiguration = gridConfiguration;
            GridSize = gridConfiguration.Size;
            UnitsPerCell = gridConfiguration.UnitsPerCell;
            _gridViewsOrdered = new List<IGridViewObject>(10);

            _gridView = gridView;
            gridView.Initialize(gridConfiguration.Size, gridConfiguration.UnitsPerCell);
            _gridView.PointerMoveUnderGameObject += OnPointerMoveUnderGameObject;
        }

        private void OnPointerMoveUnderGameObject()
        {
            throw new System.NotImplementedException();
        }

        public bool TryPlaceOnGrid(IGridViewObject gridViewObject)
        {
            throw new System.NotImplementedException();
        }

        public bool IsCellFilled(Vector2Int position)
        {
            var result = FindGridViewObject(position);

            return result != null;
        }

        private IGridViewObject FindGridViewObject(Vector2Int position)
        {
            return _gridViewsOrdered.BinarySearch<IGridViewObject>(item =>
            {
                if (position.x != item.GridPosition.x)
                {
                    return (int)Mathf.Sign(position.x - item.GridPosition.x);
                }
                if (position.y != item.GridPosition.y)
                {
                    return (int)Mathf.Sign(position.y - item.GridPosition.y);
                }

                return 0;
            }, out _);
        }
        
        public Vector2Int WorldToGridPosition(Vector2 pos)
        {
            var middleOfCell = _gridConfiguration.UnitsPerCell / 2;
            var xf = pos.x / middleOfCell;
            var yf = pos.y / middleOfCell;
            
            return new(RoundUp(xf), RoundUp(yf));

            int RoundUp(float f)
            {
                int i = (int)f;
                if (f > i) return i + 1;
                return i;
            }
        }

        public GridSystemPD GetSaveData()
        {
            throw new System.NotImplementedException();
        }

        public void LoadSaveData(GridSystemPD data)
        {
            throw new System.NotImplementedException();
        }
    }
}