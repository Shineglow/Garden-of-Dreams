using GardenOfDreamsTestProject.Scripts.Configuration.Buildings;
using GardenOfDreamsTestProject.Scripts.Core.Serialization.Persistant;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Buildings
{
    public class BuildingPD : IPersistantData
    {
        public EBuildings BuildingType;
        public Vector2 WorldPosition;
        
    }
}