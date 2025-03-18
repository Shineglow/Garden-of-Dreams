using System.Collections.Generic;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Configuration.Buildings
{
    public class BuildingConfigurationData : IBuildingInfo
    {
        public string Name { get; set; }
        public (EBuildingsSprites sprite, bool partOfAtlas) SpriteInfo { get; set; }
        public IReadOnlyList<IReadOnlyList<bool>> CellsToPlace { get; set; }
        public (bool automatic, Vector2 anchorPosition) LocalCellAnchorPosition { get; set; }
    }
}