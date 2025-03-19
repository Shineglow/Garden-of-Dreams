using GardenOfDreamsTestProject.Scripts.Gameplay.Grid;
using GardenOfDreamsTestProject.Scripts.Gameplay.UI.Building;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.World
{
    public class BuildingGameplaySystem : IBuildingGameplaySystem
    {
        public BuildingGameplaySystem(IGridSystem gridSystem, IBuildingUIModel model)
        {
            var a = CompositionRoot.GetAllConfigurations();
            // model.AddBuildingsRange();
        }
    }
}
