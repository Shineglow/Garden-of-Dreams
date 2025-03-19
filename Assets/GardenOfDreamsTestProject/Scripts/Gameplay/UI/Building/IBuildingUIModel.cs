using System;
using System.Collections.Generic;
using GardenOfDreamsTestProject.Scripts.Configuration.Buildings;
using GardenOfDreamsTestProject.Scripts.Core.Reactive;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.UI.Building
{
    public interface IBuildingUIModel
    {
        public TemplateReactiveProperty<EBuildings> SelectedBuilding { get; }
        public IReadOnlyCollection<EBuildings> AllBuildingsAvailableToSelect { get; }
        event Action<EBuildings> BuildingAdd;
        void AddBuilding(EBuildings buildingType);
        void AddBuildingsRange(IEnumerable<EBuildings> buildingTypes);
    }
}