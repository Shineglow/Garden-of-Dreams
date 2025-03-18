using System.Collections.Generic;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Configuration.Buildings
{
    public interface IBuildingInfo
    {
        string Name { get; }
        (EBuildingsSprites sprite, bool partOfAtlas) SpriteInfo { get; }
        (bool automatic, Vector2 anchorPosition) LocalCellAnchorPosition { get; }
        IReadOnlyList<IReadOnlyList<bool>> CellsToPlace { get; }
    }
}
