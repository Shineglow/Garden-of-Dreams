using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using GardenOfDreamsTestProject.Scripts.Configuration.Buildings;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Configuration
{
    public class ResourcesPaths : AbstractConfiguration<Type, string>
    {
        protected override Dictionary<Type, string> _typeToData { get; } = new()
        {
            {typeof(EBuildingsSprites), "Sprites/Buildings"},
        };

        public string GetResourceFolderPath(Type type)
        {
            if (_typeToData.TryGetValue(type, out var path))
            {
                return path;
            }

            throw new ArgumentException("Invalid resource type or resource path not set for the resource type.");
        }

        public string GetFullResourcePath(Type type, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("Invalid file name. File name null, empty, or contains only white spaces.");

            return GetResourceFolderPath(type) + "/" + fileName;
        }

        public static string GetAtlasSpritePath(string slicedSpriteName)
        {
            var atlasName = slicedSpriteName.Split('_').First();
            return atlasName + "/" + slicedSpriteName;
        }
    }
}