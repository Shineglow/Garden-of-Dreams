using System.Collections.Generic;
using GardenOfDreamsTestProject.Scripts.Configuration.Buildings;
using GardenOfDreamsTestProject.Scripts.Core.Reactive;
using GardenOfDreamsTestProject.Scripts.Core.Serialization;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Buildings
{
    public interface IBuildingModel : ISerializeable<BuildingPD>
    {
        EBuildings BuildingType { get; }
        Vector2Int GridPosition { get; }
        IReadOnlyList<IReadOnlyList<bool>> CellsToPlace { get; set; }
        Vector2Int LocalCellAnchorPosition { get; set; }
        BoolReactiveProperty IsNeedToPlace { get; }
        BoolReactiveProperty IsNeedToDestroy { get; }
    }
}