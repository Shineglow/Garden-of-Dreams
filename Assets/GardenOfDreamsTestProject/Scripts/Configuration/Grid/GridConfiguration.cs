using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Configuration.Grid
{
    public class GridConfiguration : IGridConfiguration
    {
        public Vector2Int Size { get; set; }
        public float UnitsPerCell { get; set; }

        public GridConfiguration()
        {
            Size = new Vector2Int(20, 20);
            UnitsPerCell = 1;
        }
    }
}