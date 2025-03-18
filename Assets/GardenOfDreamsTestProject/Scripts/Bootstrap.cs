using GardenOfDreamsTestProject.Scripts.Configuration;
using GardenOfDreamsTestProject.Scripts.Gameplay.World;
using GardenOfDreamsTestProject.Scripts.Serialization;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts
{
    public class Bootstrap : MonoBehaviour
    {
        public SaveSystem<WorldPD> SaveSystem { get; private set; }
        public ResourcesPaths ResourcesPaths { get; private set; }

        private void Awake()
        {
            SaveSystem = new SaveSystem<WorldPD>();
            ResourcesPaths = new ResourcesPaths();
        }
    }
}