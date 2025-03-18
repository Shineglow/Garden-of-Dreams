using System.Collections.Generic;
using GardenOfDreamsTestProject.Scripts.Core.Serialization.Persistant;
using GardenOfDreamsTestProject.Scripts.Serialization;

namespace GardenOfDreamsTestProject.Scripts.Core.Serialization
{
    public interface ISaveSystem<T> where T : IPersistantData
    {
        void Save(string fileName);
        void Load(string fileName);
        void SetRootObject(ISerializeable<T> rootObject);
        IEnumerable<string> GetAllSaves();
    }
}