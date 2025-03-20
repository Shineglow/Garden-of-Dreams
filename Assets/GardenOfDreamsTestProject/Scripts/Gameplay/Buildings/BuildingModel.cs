using System.Collections.Generic;
using GardenOfDreamsTestProject.Scripts.Configuration.Buildings;
using GardenOfDreamsTestProject.Scripts.Core.Reactive;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Buildings
{
    public class BuildingModel : IBuildingModel
    {
        public EBuildings BuildingType { get; private set; }
        public Vector2Int GridPosition { get; private set; }
        public IReadOnlyList<IReadOnlyList<bool>> CellsToPlace { get; set; }
        public Vector2Int LocalCellAnchorPosition { get; set; }
        
        public BoolReactiveProperty IsNeedToPlace { get; } = new BoolReactiveProperty(false, true);
        public BoolReactiveProperty IsNeedToDestroy { get; } = new BoolReactiveProperty(false, true);

        private BuildingPD _cachedPD;
        
        public BuildingModel(IBuildingConfigurationData config)
        {
            BuildingType = config.BuildingType;
            GridPosition = Vector2Int.zero;
        }

        public BuildingPD GetSaveData()
        {
            _cachedPD ??= new BuildingPD();
            
            _cachedPD.BuildingType = BuildingType;
            _cachedPD.GridPosition = GridPosition;

            return _cachedPD;
        }

        public void LoadSaveData(BuildingPD data)
        {
            _cachedPD = data;
            BuildingType = _cachedPD.BuildingType;
            GridPosition = _cachedPD.GridPosition;
        }
    }
}