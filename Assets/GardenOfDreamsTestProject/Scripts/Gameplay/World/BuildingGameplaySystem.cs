using GardenOfDreamsTestProject.Scripts.Gameplay.Grid;
using GardenOfDreamsTestProject.Scripts.Gameplay.UI.Building;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.World
{
    public class BuildingGameplaySystem : IBuildingGameplaySystem
    {
        private readonly IGridSystem _gridSystem;
        private readonly IBuildingUIModel _model;

        public BuildingGameplaySystem(IGridSystem gridSystem, IBuildingUIModel model)
        {
            _gridSystem = gridSystem;
            _model = model;
            var a = CompositionRoot.GetAllConfigurations();
            // model.
        }
    }
}
