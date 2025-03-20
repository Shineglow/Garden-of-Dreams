using GardenOfDreamsTestProject.Scripts.Configuration;
using GardenOfDreamsTestProject.Scripts.Core.Camera;
using GardenOfDreamsTestProject.Scripts.Core.Input;
using GardenOfDreamsTestProject.Scripts.Core.ResourcesSystem;
using GardenOfDreamsTestProject.Scripts.Core.Serialization;
using GardenOfDreamsTestProject.Scripts.Gameplay.Factories;
using GardenOfDreamsTestProject.Scripts.Gameplay.Grid;
using GardenOfDreamsTestProject.Scripts.Gameplay.UI;
using GardenOfDreamsTestProject.Scripts.Gameplay.World;

namespace GardenOfDreamsTestProject.Scripts.Gameplay
{
    public static class CompositionRoot
    {
        private static ISaveSystem<WorldPD> SaveSystem;
        private static ResourcesLoader ResourcesLoader;
        private static IAllConfigurations AllConfigurations;
        private static AllFactories AllFactories;
        private static GameplayUISystem GameplayUISystem;
        private static IGridSystem GridSystem;
        private static IInputSystem InputSystem;
        private static ICameraSystem _cameraSystemSystem;

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

        public static IGridSystem GetGridSystem()
        {
            var gridView = GetResourcesLoader().CreatePrefabInstance<GridView, EGameplayPrefabs>(EGameplayPrefabs.GridView);
            GridSystem = new GridSystem();
            GridSystem.Initialize(GetAllConfigurations().GetGridConfiguration(), gridView);
            return GridSystem;
        }

        public static IInputSystem GetInputSystem()
        {
            return InputSystem ??= new InputSystem();
        }

        public static IAllFactories GetAllFactories()
        {
            return AllFactories ??= new AllFactories();
        }

        public static ICameraSystem GetCamera()
        {
            return _cameraSystemSystem ??= GetResourcesLoader()
                .CreatePrefabInstance<CameraSystem, EGeneralPrefabs>(EGeneralPrefabs.MainCamera);
        }
    }
}