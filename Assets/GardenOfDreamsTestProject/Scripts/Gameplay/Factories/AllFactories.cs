using GardenOfDreamsTestProject.Scripts.Gameplay.Factories.Buildings;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Factories
{
    public class AllFactories : IAllFactories
    {
        private BuildingsesFactory _buildingsesFactory;

        public IBuildingsFactory GetBuildingsFactory()
        {
            return _buildingsesFactory ??= new BuildingsesFactory();
        }
    }
}