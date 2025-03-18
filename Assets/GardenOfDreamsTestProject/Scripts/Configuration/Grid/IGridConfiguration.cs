using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Configuration.Grid
{
    public interface IGridConfiguration
    {
        Vector2Int Size { get; }
        float UnitsPerCell { get; }
    }
}