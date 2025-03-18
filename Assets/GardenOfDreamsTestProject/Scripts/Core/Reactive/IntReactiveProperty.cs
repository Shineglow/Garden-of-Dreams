using System;

namespace GardenOfDreamsTestProject.Scripts.Core.Reactive
{
    public sealed class IntReactiveProperty : IReadOnlyReactiveProperty<int>
    {
        private int _value;
        private int _actualValue;
        private readonly int _minimumChangeStep;

        public int Value
        {
            get => _value;
            set
            {
                _actualValue = value;
                if (_value - _actualValue < _minimumChangeStep)
                    return;
                int oldValue = _value;
                _value = _actualValue;
                ValueChanged?.Invoke(oldValue, _value);
            }
        }

        public event Action<int, int> ValueChanged;
        
        public IntReactiveProperty(int initialValue, int minimumChangeStep)
        {
            _value = initialValue;
            _minimumChangeStep = minimumChangeStep;
        }
    }
}