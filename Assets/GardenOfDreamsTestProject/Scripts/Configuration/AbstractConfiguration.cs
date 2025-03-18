using System;
using System.Collections.Generic;

namespace GardenOfDreamsTestProject.Scripts.Configuration
{
    public abstract class AbstractConfiguration<T1, T2> : IConfiguration<T1, T2>
    {
        protected abstract Dictionary<T1, T2> _typeToData { get; }
        
        public T2 GetData(T1 configurationOfType)
        {
            if (!_typeToData.TryGetValue(configurationOfType, out var data))
                throw new ArgumentException($"{nameof(configurationOfType)} not valid or configuration miss");
            return data;
        }
    }
}