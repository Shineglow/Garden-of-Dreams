using System.Collections.Generic;
using GardenOfDreamsTestProject.Scripts.Configuration.Buildings;
using GardenOfDreamsTestProject.Scripts.Serialization;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Buildings
{
    public class BuildingModel : ISerializeable<BuildingPD>
    {
        public EBuildings BuildingType { get; private set; }
        public Vector2 WorldPosition { get; private set; }
        public string Name { get; set; }
        public (EBuildingsSprites sprite, bool partOfAtlas) SpriteInfo { get; set; }
        public IReadOnlyList<IReadOnlyList<bool>> CellsToPlace { get; set; }
        public (bool automatic, Vector2 anchorPosition) LocalCellAnchorPosition { get; set; }

        private BuildingPD _cachedPD;
        
        public BuildingModel(BuildingConfigurationData config)
        {
            Name = config.Name;
        }

        public BuildingPD GetSaveData()
        {
            _cachedPD ??= new BuildingPD();
            
            _cachedPD.BuildingType = BuildingType;
            _cachedPD.WorldPosition = WorldPosition;

            return _cachedPD;
        }

        public void LoadSaveData(BuildingPD data)
        {
            _cachedPD = data;
            BuildingType = _cachedPD.BuildingType;
            WorldPosition = _cachedPD.WorldPosition;
        }
    }
}