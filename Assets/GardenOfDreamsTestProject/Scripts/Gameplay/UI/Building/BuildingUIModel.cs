using System;
using System.Collections.Generic;
using GardenOfDreamsTestProject.Scripts.Configuration.Buildings;
using GardenOfDreamsTestProject.Scripts.Core.Reactive;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.UI.Building
{
    public class BuildingUIModel : IBuildingUIModel
    {
        public TemplateReactiveProperty<EBuildings> SelectedBuilding { get; set; }
        public IReadOnlyCollection<EBuildings> AllBuildingsAvailableToSelect => _buildingsSet;

        private HashSet<EBuildings> _buildingsSet = new ();

        public event Action<EBuildings> BuildingAdd;

        public void AddBuilding(EBuildings buildingType)
        {
            if (_buildingsSet.Contains(buildingType))
            {
                Debug.LogError($"Collection already contains building {buildingType}");
                return;
            }

            _buildingsSet.Add(buildingType);
            BuildingAdd?.Invoke(buildingType);
        }
        
        public void AddBuildingsRange(IEnumerable<EBuildings> buildingTypes)
        {
            foreach (var buildingType in buildingTypes)
            {
                AddBuilding(buildingType);
            }
        }
    }
}