using System;
using System.Collections.Generic;
using GardenOfDreamsTestProject.Scripts.Configuration.Grid;
using GardenOfDreamsTestProject.Scripts.Core.Camera;
using GardenOfDreamsTestProject.Scripts.Core.Serialization;
using GardenOfDreamsTestProject.Scripts.Gameplay.Buildings;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Grid
{
    public class GridSystem : IGridSystem, ISerializeable<GridSystemPD>
    {
        private List<List<IBuildingModel>> _gridCells;
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
            _gridCells = new List<List<IBuildingModel>>(gridConfiguration.Size.x * gridConfiguration.Size.y);
            _cameraSystem = CompositionRoot.GetCameraSystem();

            _gridView = gridView;
            gridView.Initialize(gridConfiguration.Size, gridConfiguration.UnitsPerCell);
            _gridView.PointerMoveUnderGameObject += OnPointerMoveUnderGameObject;
        }

        private void OnPointerMoveUnderGameObject()
        {
            PointerMoveUnderGrid?.Invoke();
        }

        public bool IsPossibleToPlace(IBuildingModel model)
        {
            Vector2Int leftBottom = model.GridPosition.Value - model.LocalCellAnchorPosition;
            Vector2Int rightTop = leftBottom + model.BoundSize;
            return IsPossibleToPlace(model, leftBottom, rightTop);
        }
        
        public bool IsPossibleToPlace(IBuildingModel model, Vector2Int leftBottom, Vector2Int rightTop)
        {
            leftBottom = model.GridPosition.Value - model.LocalCellAnchorPosition;
            rightTop = leftBottom + model.BoundSize;

            if (leftBottom.x < 0 || rightTop.x >= GridSize.x || leftBottom.y < 0 || rightTop.y >= GridSize.y)
                return false;
            
            for (int x = leftBottom.x; x < rightTop.x; x++)
            {
                for (int y = leftBottom.y; y < rightTop.y; y++)
                {
                    if (!model.CellsToPlace[x][y]) continue;
                    if (_gridCells[x][y] != null)
                        return false;
                }
            }

            return true;
        }
        
        public bool TryPlaceBuildingOnGrid(IBuildingModel model)
        {
            Vector2Int leftBottom = model.GridPosition.Value - model.LocalCellAnchorPosition;
            Vector2Int rightTop = leftBottom + model.BoundSize;
            if (!IsPossibleToPlace(model, leftBottom, rightTop))
                return false;
            
            for (int x = leftBottom.x; x < rightTop.x; x++)
            {
                for (int y = leftBottom.y; y < rightTop.y; y++)
                {
                    if (!model.CellsToPlace[x][y]) continue;
                    _gridCells[x][y] = model;
                }
            }

            return true;
        }

        public bool TryDestroyBuilding(IBuildingModel model)
        {
            Vector2Int leftBottom = model.GridPosition.Value - model.LocalCellAnchorPosition;
            Vector2Int rightTop = leftBottom + model.BoundSize;

            if (leftBottom.x < 0 || rightTop.x >= GridSize.x || leftBottom.y < 0 || rightTop.y >= GridSize.y)
                return false;
            
            for (int x = leftBottom.x; x < rightTop.x; x++)
            {
                for (int y = leftBottom.y; y < rightTop.y; y++)
                {
                    if (!model.CellsToPlace[x][y]) continue;
                    _gridCells[x][y] = null;
                }
            }

            return true;
        }

        public bool IsCellFilled(Vector2Int position) => _gridCells[position.x][position.y] != null;

        #region PositionConvertationMethods

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

        #endregion

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