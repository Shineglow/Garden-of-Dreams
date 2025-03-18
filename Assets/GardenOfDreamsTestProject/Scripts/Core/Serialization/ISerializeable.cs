using GardenOfDreamsTestProject.Scripts.Core.Serialization.Persistant;

namespace GardenOfDreamsTestProject.Scripts.Serialization
{
    public interface ISerializeable<T> where T : IPersistantData
    {
        T GetSaveData();
        void LoadSaveData(T data);
    }
}