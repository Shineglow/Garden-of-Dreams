using GardenOfDreamsTestProject.Scripts.Gameplay.Grid;
using GardenOfDreamsTestProject.Scripts.Serialization;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.World
{
    public class WorldEntity : ISerializeable<WorldPD>
    {
        private IGridSystem _gridSystem;

        public WorldEntity(IGridSystem gridSystem)
        {
            _gridSystem = gridSystem;
        }
        
        public WorldPD GetSaveData()
        {
            throw new System.NotImplementedException();
        }

        public void LoadSaveData(WorldPD data)
        {
            throw new System.NotImplementedException();
        }
    }
}