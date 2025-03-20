using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using GardenOfDreamsTestProject.Scripts.Gameplay.Grid;
using GardenOfDreamsTestProject.Scripts.Gameplay.UI;
using GardenOfDreamsTestProject.Scripts.Gameplay.UI.Building;
using GardenOfDreamsTestProject.Scripts.Gameplay.World;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.ScenesStarters
{
    public class MainSceneStarter : MonoBehaviour
    {
        private IGridSystem _gridSystem;
        private BuildingUIModel _buildingUIModel;
        private BuildingGameplaySystem _buildingGameplaySystem;
        private GameplayUISystem _gameplayUISystem;

        private async void Awake()
        {
            var resourcesLoader = CompositionRoot.GetResourcesLoader();
            var allConfigurations = CompositionRoot.GetAllConfigurations();

            _gameplayUISystem = CompositionRoot.GetGameplayUISystem();

            _gridSystem = CompositionRoot.GetGridSystem();

            var buildingViewInstance = resourcesLoader.CreatePrefabInstance<BuildingUIView, EUIPrefabs>(EUIPrefabs.Building_UI);
            _buildingUIModel = new BuildingUIModel();
            var buildingUIViewModel = new BuildingUIViewModel(allConfigurations.GetBuildingsConfiguration(), resourcesLoader);
            await UniTask.Yield();
            var rectTransform = buildingViewInstance.GetComponent<RectTransform>();
            _gameplayUISystem.SetParentOfLayer(rectTransform, EGameplayUILayers.Gameplay);
            buildingViewInstance.ResetTransformParameters();
            await UniTask.Yield();
            buildingUIViewModel.Initialize(buildingViewInstance, _buildingUIModel);

            _buildingGameplaySystem = new BuildingGameplaySystem(_gridSystem, _buildingUIModel);
        }
    }
}
