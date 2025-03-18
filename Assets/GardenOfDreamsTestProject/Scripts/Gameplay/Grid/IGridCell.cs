namespace GardenOfDreamsTestProject.Scripts.Gameplay.Grid
{
    public interface IGridCell
    {
        public bool IsFilled { get; }
        public IGridViewObject PlacedObject { get; }
    }
}