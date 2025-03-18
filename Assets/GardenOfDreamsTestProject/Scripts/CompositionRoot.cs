using GardenOfDreamsTestProject.Scripts.Configuration;
using GardenOfDreamsTestProject.Scripts.Core.ResourcesSystem;
using GardenOfDreamsTestProject.Scripts.Core.Serialization;
using GardenOfDreamsTestProject.Scripts.Gameplay.Grid;
using GardenOfDreamsTestProject.Scripts.Gameplay.World;

namespace GardenOfDreamsTestProject.Scripts
{
    public static class CompositionRoot
    {
        public static IGridSystem GridSystem { get; private set; }
        public static ISaveSystem<WorldPD> SaveSystem { get; private set; }
        public static ResourcesLoader ResourcesLoader { get; private set; }
        public static IAllConfigurations AllConfigurations { get; private set; }

        static CompositionRoot()
        {
            GridSystem = new GridSystem();
            SaveSystem = new SaveSystem<WorldPD>();
            ResourcesLoader = new ResourcesLoader();
            AllConfigurations = new AllConfigurations();
        }
    }
}