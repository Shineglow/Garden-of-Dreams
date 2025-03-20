using System;
using System.Collections.Generic;
using GardenOfDreamsTestProject.Scripts.Configuration.Grid;
using GardenOfDreamsTestProject.Scripts.Core.Camera;
using GardenOfDreamsTestProject.Scripts.Core.Extensions;
using GardenOfDreamsTestProject.Scripts.Core.Serialization;
using GardenOfDreamsTestProject.Scripts.Gameplay.Buildings;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Grid
{
    public class GridSystem : IGridSystem, ISerializeable<GridSystemPD>
    {
        private List<IBuildingModel> _gridViewsOrdered;
        private IGridView _gridView;
        private IGridConfiguration _gridConfiguration;
        private ICameraSystem _cameraSystem;

        public float UnitsPerCell { get; private set; }
        public Vector2Int GridSize { get; private set; }

        public event Action PointerMoveUnderGrid;

        public void Initialize(IGridConfiguration gridConfiguration, IGridView gridView)
        {
            _gridConfiguration = gridConfiguration;
            GridSize = gridConfiguration.Size;
            UnitsPerCell = gridConfiguration.UnitsPerCell;
            _gridViewsOrdered = new List<IBuildingModel>(10);
            _cameraSystem = CompositionRoot.GetCamera();

            _gridView = gridView;
            gridView.Initialize(gridConfiguration.Size, gridConfiguration.UnitsPerCell);
            _gridView.PointerMoveUnderGameObject += OnPointerMoveUnderGameObject;
        }

        private void OnPointerMoveUnderGameObject()
        {
            PointerMoveUnderGrid?.Invoke();
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

        private IBuildingModel FindGridViewObject(Vector2Int position)
        {
            return _gridViewsOrdered.BinarySearch(item =>
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
            var xf = pos.x / _gridConfiguration.UnitsPerCell;
            var yf = pos.y / _gridConfiguration.UnitsPerCell;
            
            return new(RoundUp(xf), RoundUp(yf));

            int RoundUp(float f)
            {
                int i = (int)f;
                if (f > i) return i + 1;
                return i;
            }
        }
        
        public Vector2 GridToLocalPosition(Vector2Int pos)
        {
            Vector2 result = new(pos.x * _gridConfiguration.UnitsPerCell, pos.y * _gridConfiguration.UnitsPerCell);
            return result;
        }

        public Vector3 GridToWorldPosition(Vector2Int pos)
        {
            return _gridView.Transform.localToWorldMatrix.MultiplyPoint3x4(GridToLocalPosition(pos));
        }

        public Vector3 MousePositionToWorldPosition(Vector2 pos)
        {
            var worldPos = _cameraSystem.ViewportToWorldPoint(pos);
            var gridPos = WorldToGridPosition(worldPos);
            var result = GridToWorldPosition(gridPos);
            return result;
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