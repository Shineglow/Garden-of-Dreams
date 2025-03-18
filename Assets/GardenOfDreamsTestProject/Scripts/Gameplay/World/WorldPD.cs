using System.Collections.Generic;
using GardenOfDreamsTestProject.Scripts.Core.Serialization.Persistant;
using GardenOfDreamsTestProject.Scripts.Gameplay.Buildings;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.World
{
    public class WorldPD : IPersistantData
    {
        public List<BuildingPD> BuildingPDs { get; } = new();
    }
}