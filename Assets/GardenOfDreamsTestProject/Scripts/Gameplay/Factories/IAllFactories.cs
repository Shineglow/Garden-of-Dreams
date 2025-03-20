using GardenOfDreamsTestProject.Scripts.Gameplay.Factories.Buildings;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Factories
{
    public interface IAllFactories
    {
        IBuildingsFactory GetBuildingsFactory();
    }
}