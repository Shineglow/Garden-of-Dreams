using System;
using GardenOfDreamsTestProject.Scripts.Configuration.Grid;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Grid
{
    public interface IGridView
    {
        Transform Transform { get; }
        
        event Action PointerMoveUnderGameObject;
        void Initialize(Vector2Int size, float unitsPerCell);
    }
}