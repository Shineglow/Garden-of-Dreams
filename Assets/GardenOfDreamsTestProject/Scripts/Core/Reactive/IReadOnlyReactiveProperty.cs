using System;

namespace GardenOfDreamsTestProject.Scripts.Core.Reactive
{
    public interface IReadOnlyReactiveProperty<T>
    {
        T Value { get; }
        event Action<T, T> ValueChanged;
    }
}