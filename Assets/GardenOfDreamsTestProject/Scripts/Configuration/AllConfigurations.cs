using GardenOfDreamsTestProject.Scripts.Configuration.Buildings;
using GardenOfDreamsTestProject.Scripts.Configuration.Grid;

namespace GardenOfDreamsTestProject.Scripts.Configuration
{
    public class AllConfigurations : IAllConfigurations
    {
        private GameConfiguration _gameConfiguration;
        private IConfiguration<EBuildings, IBuildingConfigurationData> _buildingsConfiguration;
        private IGridConfiguration _gridConfiguration;

        public IConfiguration<EBuildings, IBuildingConfigurationData> GetBuildingsConfiguration() => _buildingsConfiguration ??= new BuildingsConfiguration();
        public IGridConfiguration GetGridConfiguration() => _gridConfiguration ??= new GridConfiguration();
        public GameConfiguration GetGameConfiguration() => _gameConfiguration ??= new GameConfiguration();
    }
}