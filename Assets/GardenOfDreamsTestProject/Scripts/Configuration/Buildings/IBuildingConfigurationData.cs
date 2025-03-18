using System.Collections.Generic;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Configuration.Buildings
{
    public interface IBuildingConfigurationData
    {
        string Name { get; }
        (EBuildingsSprites sprite, bool isPartOfAtlas) SpriteInfo { get; }
        (bool automatic, Vector2 anchorPosition) LocalCellAnchorPosition { get; }
        IReadOnlyList<IReadOnlyList<bool>> CellsToPlace { get; }
    }
}
