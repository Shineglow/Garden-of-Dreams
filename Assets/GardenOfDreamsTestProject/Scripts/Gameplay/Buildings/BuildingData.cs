using System.Collections.Generic;
using System.Numerics;
using GardenOfDreamsTestProject.Scripts.Configuration;
using GardenOfDreamsTestProject.Scripts.Configuration.Buildings;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Buildings
{
    public class BuildingData
    {
        public string Name { get; set; }
        public (EBuildingsSprites sprite, bool partOfAtlas) SpriteInfo { get; set; }
        public IReadOnlyList<IReadOnlyList<bool>> CellsToPlace { get; set; }
        public (bool automatic, Vector2 anchorPosition) LocalCellAnchorPosition { get; set; }

        public readonly string SpriteResourceCachedPath;
        
        public BuildingData(BuildingConfigurationData config)
        {
            SpriteResourceCachedPath = config.SpriteInfo.partOfAtlas ? 
                ResourcesPaths.GetAtlasSpritePath(nameof(config.SpriteInfo.sprite)) : 
                nameof(config.SpriteInfo.sprite);
            Name = config.Name;
        }
    }
}