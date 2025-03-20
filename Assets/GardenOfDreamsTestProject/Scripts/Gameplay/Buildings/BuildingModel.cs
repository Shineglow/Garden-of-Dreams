using System.Collections.Generic;
using System.Linq;
using GardenOfDreamsTestProject.Scripts.Configuration.Buildings;
using GardenOfDreamsTestProject.Scripts.Core.Reactive;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Buildings
{
    public class BuildingModel : IBuildingModel
    {
        public EBuildings BuildingType { get; private set; }
        public TemplateReactiveProperty<Vector2Int> GridPosition { get; } = new TemplateReactiveProperty<Vector2Int>(Vector2Int.zero);
        public IReadOnlyList<IReadOnlyList<bool>> CellsToPlace { get;  }
        public Vector2Int LocalCellAnchorPosition { get; }
        public Vector2Int BoundSize { get; }

        public BoolReactiveProperty IsNeedToPlace { get; } = new(false, true);
        public BoolReactiveProperty IsShadowObject { get; } = new(false, false);
        public BoolReactiveProperty IsNeedToDestroy { get; } = new(false, true);

        private BuildingPD _cachedPD;
        
        public BuildingModel(IBuildingConfigurationData config)
        {
            BuildingType = config.BuildingType;
            GridPosition.Value = Vector2Int.zero;

            int size = 0;
            foreach (var readOnlyList in config.CellsToPlace)
            {
                if (readOnlyList.Count > size)
                    size = readOnlyList.Count;
            }
            
            BoundSize = new Vector2Int(config.CellsToPlace.Count, size);
            CellsToPlace = config.CellsToPlace;
            LocalCellAnchorPosition = LocalCellAnchorPosition;
        }

        public BuildingPD GetSaveData()
        {
            _cachedPD ??= new BuildingPD();
            
            _cachedPD.BuildingType = BuildingType;
            _cachedPD.GridPosition = GridPosition.Value;

            return _cachedPD;
        }

        public void LoadSaveData(BuildingPD data)
        {
            _cachedPD = data;
            BuildingType = _cachedPD.BuildingType;
            GridPosition.Value = _cachedPD.GridPosition;
        }
    }
}