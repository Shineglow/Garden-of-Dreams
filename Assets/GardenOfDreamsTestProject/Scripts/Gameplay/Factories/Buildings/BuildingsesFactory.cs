using GardenOfDreamsTestProject.Scripts.Configuration;
using GardenOfDreamsTestProject.Scripts.Configuration.Buildings;
using GardenOfDreamsTestProject.Scripts.Core.ResourcesSystem;
using GardenOfDreamsTestProject.Scripts.Gameplay.Buildings;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Factories.Buildings
{
    public class BuildingsesFactory : IBuildingsFactory
    {
        private readonly ResourcesLoader _resourcesLoader;
        private readonly IConfiguration<EBuildings, IBuildingConfigurationData> _buildingsConfiguration;

        public BuildingsesFactory()
        {
            _resourcesLoader = CompositionRoot.GetResourcesLoader();
            _buildingsConfiguration = CompositionRoot.GetAllConfigurations().GetBuildingsConfiguration();
        }
        
        public IBuildingModel GetBuilding(EBuildings building)
        {
            var buildingPrefabInstance = _resourcesLoader.CreatePrefabInstance<IBuildingView, EGameplayPrefabs>(EGameplayPrefabs.BuildingPrefab);
            var buildingModel = new BuildingModel(_buildingsConfiguration.GetData(building));
            _ = new BuildingViewModel(buildingModel, buildingPrefabInstance);
            return buildingModel;
        }
    }
}