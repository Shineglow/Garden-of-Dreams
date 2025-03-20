using System;
using GardenOfDreamsTestProject.Scripts.Configuration.Grid;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Grid
{
    public interface IGridSystem
    {
        float UnitsPerCell { get; }
        Vector2Int GridSize { get; }

        bool TryPlaceOnGrid(IGridViewObject gridViewObject);
        bool IsCellFilled(Vector2Int position);
        Vector2Int WorldToGridPosition(Vector2 pos);
        event Action PointerMoveUnderGrid;
        void Initialize(IGridConfiguration gridConfiguration, IGridView gridView);
    }
}