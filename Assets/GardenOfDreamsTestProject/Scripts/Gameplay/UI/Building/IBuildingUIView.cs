using System;
using System.Collections.Generic;
using GardenOfDreamsTestProject.Scripts.Configuration.Buildings;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.UI.Building
{
    public interface IBuildingUIView
    {
        event Action<EBuildings> BuildingSelected;
        event Action BuildButtonPressed;
        event Action DestroyButtonPressed;
        void Initialize(List<(EBuildings buildingType, Sprite sprite)> buildingsInfo, int firstSelected);
        void SetSelectedBuilding(EBuildings building);
        void ResetTransformParameters();
    }
}