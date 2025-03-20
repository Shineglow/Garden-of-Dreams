using System.Collections.Generic;
using GardenOfDreamsTestProject.Scripts.Core.Serialization;
using GardenOfDreamsTestProject.Scripts.Gameplay.Buildings;
using GardenOfDreamsTestProject.Scripts.Gameplay.Grid;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.World
{
    public class WorldModel : ISerializeable<WorldPD>
    {
        private IGridSystem _gridSystem;
        private List<BuildingModel> _buildings;

        private WorldPD _cachedPD;

        public WorldModel(IGridSystem gridSystem)
        {
            _gridSystem = gridSystem;
            _buildings = new();
        }
        
        public WorldPD GetSaveData()
        {
            _cachedPD ??= new WorldPD();
            if (_buildings is {Count: > 0})
            {
                List<BuildingPD> buildingsPDs = _cachedPD.BuildingPDs;

                foreach (var building in _buildings)
                {
                    buildingsPDs.Add(building.GetSaveData());
                }
            }

            return _cachedPD;
        }

        public void LoadSaveData(WorldPD data)
        {
            _cachedPD = data;
            if (data.BuildingPDs is {Count: > 0})
            {
                List<BuildingPD> buildingsPDs = _cachedPD.BuildingPDs;

                for (var i = 0; i < _buildings.Count; i++)
                {
                    _buildings[i].LoadSaveData(buildingsPDs[i]);
                }
            }
        }
    }
}