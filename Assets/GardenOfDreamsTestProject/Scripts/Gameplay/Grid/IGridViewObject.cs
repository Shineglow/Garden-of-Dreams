using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Grid
{
    public interface IGridViewObject
    {
        string Name { get; }
        Vector2Int GridPosition { get; }
    }
}