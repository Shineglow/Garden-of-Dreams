using System;
using GardenOfDreamsTestProject.Scripts.Core.EventSystemEntities;
using GardenOfDreamsTestProject.Scripts.Gameplay.Grid;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Buildings
{
    public interface IBuildingView : IGridViewObject, IPointerEventReceiver
    {
        event Action PointerDown;
    }
}