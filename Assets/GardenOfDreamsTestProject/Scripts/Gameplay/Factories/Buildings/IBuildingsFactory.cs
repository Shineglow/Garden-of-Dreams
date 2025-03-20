using GardenOfDreamsTestProject.Scripts.Configuration.Buildings;
using GardenOfDreamsTestProject.Scripts.Gameplay.Buildings;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Factories.Buildings
{
    public interface IBuildingsFactory
    {
        IBuildingModel GetBuilding(EBuildings building);
    }
}