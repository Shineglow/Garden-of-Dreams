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
        TemplateReactiveProperty<Vector2Int> GridPosition { get; }
        IReadOnlyList<IReadOnlyList<bool>> CellsToPlace { get; }
        Vector2Int LocalCellAnchorPosition { get; }
        Vector2Int BoundSize { get; }
        BoolReactiveProperty IsNeedToPlace { get; }
        BoolReactiveProperty IsShadowObject { get; }
        BoolReactiveProperty IsNeedToDestroy { get; }
    }
}