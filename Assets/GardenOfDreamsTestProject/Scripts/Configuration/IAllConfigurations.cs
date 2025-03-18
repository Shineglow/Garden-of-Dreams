using GardenOfDreamsTestProject.Scripts.Configuration.Buildings;
using GardenOfDreamsTestProject.Scripts.Configuration.Grid;

namespace GardenOfDreamsTestProject.Scripts.Configuration
{
    public interface IAllConfigurations
    {
        IConfiguration<EBuildings, IBuildingConfigurationData> GetBuildingsConfiguration();
        IGridConfiguration GetGridConfiguration();
        GameConfiguration GetGameConfiguration();
    }
}