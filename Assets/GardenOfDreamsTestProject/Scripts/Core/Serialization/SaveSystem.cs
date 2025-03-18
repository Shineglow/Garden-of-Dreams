using System.Collections.Generic;
using System.IO;
using System.Linq;
using GardenOfDreamsTestProject.Scripts.Core.Serialization.Persistant;
using GardenOfDreamsTestProject.Scripts.Serialization;
using Newtonsoft.Json;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Core.Serialization
{
    public class SaveSystem<T> : ISaveSystem<T> where T : IPersistantData
    {
        private static readonly string SavesPath = $"{Application.persistentDataPath}/saves";
        private static readonly string SaveExtension = ".save";
        private ISerializeable<T> _rootObject;
        
        private string GetFullSavePath(string fileName) => $"{SavesPath}/{fileName}.save";

        public void SetRootObject(ISerializeable<T> rootObject)
        {
            _rootObject = rootObject;
        }

        public IEnumerable<string> GetAllSaves()
        {
            if (!Directory.Exists(SavesPath))
                return null;

            return Directory.GetFiles(SavesPath, $"*{SaveExtension}").Select(i => i.Split('/').Last());
        }

        public void Save(string fileName)
        {
            if (!Directory.Exists(SavesPath))
                Directory.CreateDirectory(SavesPath);
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