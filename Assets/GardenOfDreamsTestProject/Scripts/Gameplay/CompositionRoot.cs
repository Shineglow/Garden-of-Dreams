using GardenOfDreamsTestProject.Scripts.Configuration;
using GardenOfDreamsTestProject.Scripts.Core.ResourcesSystem;
using GardenOfDreamsTestProject.Scripts.Core.Serialization;
using GardenOfDreamsTestProject.Scripts.Gameplay.UI;
using GardenOfDreamsTestProject.Scripts.Gameplay.World;

namespace GardenOfDreamsTestProject.Scripts.Gameplay
{
    public static class CompositionRoot
    {
        private static ISaveSystem<WorldPD> SaveSystem;
        private static ResourcesLoader ResourcesLoader;
        private static IAllConfigurations AllConfigurations;
        private static GameplayUISystem GameplayUISystem;

        static CompositionRoot()
        {
            SaveSystem = new SaveSystem<WorldPD>();
            ResourcesLoader = new ResourcesLoader();
            AllConfigurations = new AllConfigurations();
        }
        
        public static ISaveSystem<WorldPD> GetSaveSystem()
        {
            return SaveSystem ??= new SaveSystem<WorldPD>();
        }
        
        public static ResourcesLoader GetResourcesLoader()
        {
            return ResourcesLoader ??= new ResourcesLoader();
        }
        
        public static IAllConfigurations GetAllConfigurations()
        {
            return AllConfigurations ??= new AllConfigurations();
        }

        public static GameplayUISystem GetGameplayUISystem()
        {
            return GameplayUISystem ??= GetResourcesLoader()
                .CreatePrefabInstance<GameplayUISystem, EGeneralPrefabs>(EGeneralPrefabs.GameplayCanvas);
        }
    }
}