using System;

namespace GardenOfDreamsTestProject.Scripts.Core.Reactive
{
    public class TemplateReactiveProperty<T> : IReadOnlyReactiveProperty<T>
    {
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                T oldValue = _value;
                _value = Value;
                ValueChanged?.Invoke(oldValue, value);
            }
        }

        public event Action<T, T> ValueChanged;

        public TemplateReactiveProperty(T initialValue)
        {
            _value = initialValue;
        }
    }
}