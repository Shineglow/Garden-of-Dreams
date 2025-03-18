namespace GardenOfDreamsTestProject.Scripts.Gameplay.Grid
{
    public class GridCell : IGridCell
    {
        public bool IsFilled => PlacedObject != null;
        public IGridViewObject PlacedObject { get; set; }
    }
}