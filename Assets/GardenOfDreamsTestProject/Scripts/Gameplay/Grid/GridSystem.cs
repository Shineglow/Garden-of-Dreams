using GardenOfDreamsTestProject.Scripts.Configuration;
using GardenOfDreamsTestProject.Scripts.Configuration.Grid;
using GardenOfDreamsTestProject.Scripts.Serialization;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Grid
{
    public class GridSystem : IGridSystem, ISerializeable<GridSystemPD>
    {
        private IGridViewObject[,] _grid;
        
        public float UnitsPerCell { get; private set; }
        public Vector2Int GridSize { get; private set; }

        public void SetConfigurationData(IGridConfiguration gridConfiguration)
        {
            GridSize = gridConfiguration.Size;
            UnitsPerCell = gridConfiguration.UnitsPerCell;
            _grid = new IGridViewObject[GridSize.x, GridSize.y];
        }
        
        public bool TryPlaceOnGrid(IGridViewObject gridViewObject)
        {
            throw new System.NotImplementedException();
        }

        public bool IsCellFilled(Vector2 position)
        {
            throw new System.NotImplementedException();
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