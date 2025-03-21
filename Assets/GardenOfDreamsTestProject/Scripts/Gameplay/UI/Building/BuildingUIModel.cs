using GardenOfDreamsTestProject.Scripts.Configuration.Buildings;
using GardenOfDreamsTestProject.Scripts.Core.Reactive;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.UI.Building
{
    public class BuildingUIModel : IBuildingUIModel
    {
        public TemplateReactiveProperty<EBuildings> SelectedBuildingEditable = new(default);
        public IReadOnlyReactiveProperty<EBuildings> SelectedBuilding => SelectedBuildingEditable;
        public IReadOnlyReactiveProperty<bool> BuildPressed => BuildPressedEditable;
        public IReadOnlyReactiveProperty<bool> DestroyPressed => DestroyPressedEditable;
        public BoolReactiveProperty BuildPressedEditable {get;} = new(false, true);
        public BoolReactiveProperty DestroyPressedEditable {get;} = new(false, true);
    }
}