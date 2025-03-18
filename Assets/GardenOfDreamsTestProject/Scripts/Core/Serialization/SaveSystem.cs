using System.IO;
using GardenOfDreamsTestProject.Scripts.Core.Serialization.Persistant;
using GardenOfDreamsTestProject.Scripts.Serialization;
using Newtonsoft.Json;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Core.Serialization
{
    public class SaveSystem<T> : ISaveSystem<T> where T : IPersistantData
    {
        private static readonly string SavesPath = Path.Combine(Application.persistentDataPath, "saves");
        private static readonly string SaveExtension = ".save";
        private ISerializeable<T> _rootObject;
        
        private string GetFullSavePath(string fileName) => Path.Combine(SavesPath,fileName) + ".save";

        public void SetRootObject(ISerializeable<T> rootObject)
        {
            _rootObject = rootObject;
        }

        public string[] GetAllSaves()
        {
            return !Directory.Exists(SavesPath) ? null : Directory.GetFiles(SavesPath, $"*{SaveExtension}");
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

        public static string LoadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}