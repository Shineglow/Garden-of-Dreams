using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Configuration
{
    public interface IGreedConfiguration
    {
        Vector2Int Size { get; }
        float UnitsPerCell { get; }
        
    }
}