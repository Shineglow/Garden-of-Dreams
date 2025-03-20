using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Grid
{
    public interface IGridViewObject
    {
        string Name { get; }
        Vector3 Position { get; set; }
    }
}