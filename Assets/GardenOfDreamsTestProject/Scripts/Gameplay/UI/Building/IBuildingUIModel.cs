using GardenOfDreamsTestProject.Scripts.Configuration.Buildings;
using GardenOfDreamsTestProject.Scripts.Core.Reactive;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.UI.Building
{
    public interface IBuildingUIModel
    {
        IReadOnlyReactiveProperty<EBuildings> SelectedBuilding { get; }
        IReadOnlyReactiveProperty<bool> BuildPressed { get; }
        IReadOnlyReactiveProperty<bool> DestroyPressed { get; }
    }
}