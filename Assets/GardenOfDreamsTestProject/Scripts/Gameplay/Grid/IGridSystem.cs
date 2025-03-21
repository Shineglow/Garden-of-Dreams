using System;
using GardenOfDreamsTestProject.Scripts.Configuration.Grid;
using GardenOfDreamsTestProject.Scripts.Gameplay.Buildings;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Grid
{
    public interface IGridSystem
    {
        float UnitsPerCell { get; }
        Vector2Int GridSize { get; }
        event Action PointerMoveUnderGrid;

        void Initialize(IGridConfiguration gridConfiguration, IGridView gridView);

        bool TryPlaceBuildingOnGrid(IBuildingModel model);
        bool TryDestroyBuilding(IBuildingModel model);
        bool IsCellFilled(Vector2Int position);
        Vector2Int WorldToGridPosition(Vector2 pos);
        Vector3 MousePositionToWorldPosition(Vector2 pos);
        bool IsPossibleToPlace(IBuildingModel actualModel);
    }
}