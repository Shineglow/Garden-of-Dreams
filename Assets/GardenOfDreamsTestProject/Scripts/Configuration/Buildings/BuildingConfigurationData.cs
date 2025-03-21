using System.Collections.Generic;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Configuration.Buildings
{
    public class BuildingConfigurationData : IBuildingConfigurationData
    {
        public EBuildings BuildingType { get; set; }
        public string Name { get; set; }
        public (EBuildingsSprites sprite, bool isPartOfAtlas) SpriteInfo { get; set; }
        public IReadOnlyList<IReadOnlyList<bool>> CellsToPlace { get; set; }
        public (bool automatic, Vector2 anchorPosition) LocalCellAnchorPosition { get; set; }
        public Vector2Int GridBoundingSize { get; set; }
    }
}