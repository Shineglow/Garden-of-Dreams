using System;
using System.Linq;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Core.ResourcesSystem
{
    public class ResourcesLoader : IResourcesLoader
    {
        public T1 CreatePrefabInstance<T1, T2>(T2 item) where T2 : Enum
        {
            var prefab = CreatePrefabInstance(item);
            var result = prefab.GetComponent<T1>();

            return result;
        }

        public GameObject CreatePrefabInstance<T>(T item) where T : Enum
        {
            var path = $"{typeof(T).Name}/{item.ToString()}";
            var asset = Resources.Load<GameObject>(path);
            var result = GameObject.Instantiate(asset);

            return result;
        }

        public T1 LoadAsset<T1, T2>(T2 item) where T1 : UnityEngine.Object where T2 : Enum
        {
            var path = $"{typeof(T2).Name}/{item.ToString()}";
            var result = Resources.Load<T1>(path);

            return result;
        }

        public Sprite[] LoadAtlas<T>(T item) where T : Enum
        {
            var path = $"{typeof(T).Name}/{item.ToString().Split('_').First()}";
            var result = Resources.LoadAll<Sprite>(path);

            return result;
        }
    }
}