using GardenOfDreamsTestProject.Scripts.Gameplay.Grid;
using GardenOfDreamsTestProject.Scripts.Gameplay.UI;
using GardenOfDreamsTestProject.Scripts.Gameplay.UI.Building;
using GardenOfDreamsTestProject.Scripts.Gameplay.World;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.ScenesStarters
{
    public class MainSceneStarter : MonoBehaviour
    {
        private GridSystem _gridSystem;
        private BuildingUIModel _buildingUIModel;
        private BuildingGameplaySystem _buildingGameplaySystem;
        private GameplayUISystem _gameplayUISystem;

        private void Awake()
        {
            var resourcesLoader = CompositionRoot.GetResourcesLoader();
            var allConfigurations = CompositionRoot.GetAllConfigurations();

            _gameplayUISystem = CompositionRoot.GetGameplayUISystem();
            
            var gridView = resourcesLoader.CreatePrefabInstance<GridView, EGameplayPrefabs>(EGameplayPrefabs.GridView);
            _gridSystem = new GridSystem();
            _gridSystem.Initialize(allConfigurations.GetGridConfiguration(), gridView);

            var buildingViewInstance = resourcesLoader.CreatePrefabInstance<BuildingUIView, EUIPrefabs>(EUIPrefabs.Building_UI);
            _buildingUIModel = new BuildingUIModel();
            var buildingUIViewModel = new BuildingUIViewModel(allConfigurations.GetBuildingsConfiguration(), resourcesLoader);
            buildingUIViewModel.Initialize(buildingViewInstance, _buildingUIModel);

            var rectTransform = buildingViewInstance.GetComponent<RectTransform>();
            _gameplayUISystem.SetParentOfLayer(rectTransform, EGameplayUILayers.Gameplay);

            _buildingGameplaySystem = new BuildingGameplaySystem(_gridSystem, _buildingUIModel);
        }
    }
}
