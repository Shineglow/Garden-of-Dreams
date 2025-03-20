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
        private readonly IConfiguration<EBuildings, IBuildingConfigurationData> _buildingsConfiguration;
        private readonly IResourcesLoader _resourcesLoader;

        private IBuildingUIView _buildingUIView;
        private IBuildingUIModel _model;
        private IGridSystem _gridSystem;

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
            
            buildingUIView.BuildButtonPressed += OnBuildButtonPressed;
            buildingUIView.DestroyButtonPressed += OnDestroyButtonPressed;
        }

        private void OnDestroyButtonPressed()
        {
            throw new NotImplementedException();
        }

        private void OnBuildButtonPressed()
        {
            _gridSystem = CompositionRoot.GetGridSystem();
            var gridViewObject = CompositionRoot.GetResourcesLoader()
                .CreatePrefabInstance<IGridViewObject, EGameplayPrefabs>(EGameplayPrefabs.BuildingPrefab);
            // _gridSystem.TryPlaceOnGrid(BuildingPrefab)
        }

        private void OnSelectedBuildingChanged(EBuildings oldBuilding, EBuildings newBuilding)
        {
            _buildingUIView.SetSelectedBuilding(newBuilding);
        }
    }
}