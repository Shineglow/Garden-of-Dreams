using System.IO;
using GardenOfDreamsTestProject.Scripts.Core.Serialization.Persistant;
using Newtonsoft.Json;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Serialization
{
    public class SaveSystem<T> where T : IPersistantData
    {
        private ISerializeable<T> _rootObject;

        private string GetFullSavePath(string fileName) => Application.persistentDataPath + Path.DirectorySeparatorChar + fileName;

        public void SetRootObject(ISerializeable<T> rootObject)
        {
            _rootObject = rootObject;
        }

        public void Save(string fileName)
        {
            File.WriteAllText(GetFullSavePath(fileName), 
                JsonConvert.SerializeObject(_rootObject.GetSaveData()));
        }

        public void Load(string fileName)
        {
            JsonConvert.DeserializeObject<T>(File.ReadAllText(GetFullSavePath(fileName)));
        }
    }
}