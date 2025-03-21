using System;
using GardenOfDreamsTestProject.Scripts.Core.EventSystemEntities;
using GardenOfDreamsTestProject.Scripts.Gameplay.Grid;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Buildings
{
    public interface IBuildingView : IGridViewObject, IPointerEventReceiver
    {
        event Action PointerDown;
        void SetView(Sprite sprite);
        void SetColor(Color shadowColorValue);
    }
}