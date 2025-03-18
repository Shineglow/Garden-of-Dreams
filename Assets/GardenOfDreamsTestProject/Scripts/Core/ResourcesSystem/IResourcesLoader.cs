using System;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Core.ResourcesSystem
{
    public interface IResourcesLoader
    {
        T1 CreatePrefabInstance<T1, T2>(T2 item) where T2 : Enum;
        GameObject CreatePrefabInstance<T>(T item) where T : Enum;
        T1 LoadAsset<T1, T2>(T2 item) where T1 : UnityEngine.Object where T2 : Enum;
    }
}