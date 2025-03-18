using System;
using System.Collections.Generic;
using GardenOfDreamsTestProject.Scripts.Configuration;
using GardenOfDreamsTestProject.Scripts.Configuration.Buildings;
using GardenOfDreamsTestProject.Scripts.Core.ResourcesSystem;
using GardenOfDreamsTestProject.Scripts.Gameplay.UI.Building;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.UI
{
    public class BuildingUIViewModel : IBuildingUIViewModel
    {
        private readonly IConfiguration<EBuildings, IBuildingConfigurationData> _buildingsConfiguration;
        private readonly IResourcesLoader _resourcesLoader;

        private IBuildingUIView _buildingUIView;
        private IBuildingUIModel _model;

        public BuildingUIViewModel(IConfiguration<EBuildings, IBuildingConfigurationData> buildingsConfiguration, IResourcesLoader resourcesLoader)
        {
            _buildingsConfiguration = buildingsConfiguration;
            _resourcesLoader = resourcesLoader;
        }

        public void Initialize(IBuildingUIView buildingUIView, IBuildingUIModel model)
        {
            _buildingUIView = buildingUIView;
            _model = model;
            
            List<(EBuildings buildingType, Sprite sprite)> buildingUIViewInitialData = new ();
            int index = 0;
            foreach (EBuildings value in Enum.GetValues(typeof(EBuildings)))
            {
                (EBuildings buildingType, Sprite sprite) data;
                var buildingConfig = _buildingsConfiguration.GetData(value);
                data.buildingType = value;
                data.sprite = _resourcesLoader.LoadSprite(buildingConfig.SpriteInfo.sprite, buildingConfig.SpriteInfo.isPartOfAtlas);
                buildingUIViewInitialData.Add(data);
            }
            
            const int FIRST_SELECTED = 1;
            buildingUIView.Initialize(buildingUIViewInitialData, FIRST_SELECTED);
            _model.SelectedBuilding.Value = buildingUIViewInitialData[FIRST_SELECTED].buildingType;
            _model.SelectedBuilding.ValueChanged += OnSelectedBuildingChanged;
        }

        private void OnSelectedBuildingChanged(EBuildings oldBuilding, EBuildings newBuilding)
        {
            _buildingUIView.SetSelectedBuilding(newBuilding);
        }
    }
}