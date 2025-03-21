using System;
using System.Collections.Generic;
using GardenOfDreamsTestProject.Scripts.Configuration;
using GardenOfDreamsTestProject.Scripts.Configuration.Buildings;
using GardenOfDreamsTestProject.Scripts.Core.ResourcesSystem;
using GardenOfDreamsTestProject.Scripts.Gameplay.Grid;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.UI.Building
{
    public class BuildingUIViewModel : IBuildingUIViewModel
    {
        private IConfiguration<EBuildings, IBuildingConfigurationData> _buildingsConfiguration;
        private IResourcesLoader _resourcesLoader;

        private IBuildingUIView _buildingUIView;
        private BuildingUIModel _model;
        private IGridSystem _gridSystem;

        public IBuildingUIModel Initialize(IBuildingUIView buildingUIView)
        {
            _buildingsConfiguration = CompositionRoot.GetAllConfigurations().GetBuildingsConfiguration();
            _resourcesLoader = CompositionRoot.GetResourcesLoader();
            _buildingUIView = buildingUIView;
            _model = new BuildingUIModel();
            
            List<(EBuildings buildingType, Sprite sprite)> buildingUIViewInitialData = new ();
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
            _model.SelectedBuildingEditable.Value = buildingUIViewInitialData[FIRST_SELECTED].buildingType;
            _model.SelectedBuildingEditable.ValueChanged += OnSelectedBuildingChanged;
            
            buildingUIView.BuildButtonPressed += OnBuildButtonPressed;
            buildingUIView.DestroyButtonPressed += OnDestroyButtonPressed;

            return _model;
        }

        private void OnDestroyButtonPressed()
        {
            _model.DestroyPressedEditable.Value = true;
        }

        private void OnBuildButtonPressed()
        {
            _model.BuildPressedEditable.Value = true;
        }

        private void OnSelectedBuildingChanged(EBuildings oldBuilding, EBuildings newBuilding)
        {
            _buildingUIView.SetSelectedBuilding(newBuilding);
        }
    }
}