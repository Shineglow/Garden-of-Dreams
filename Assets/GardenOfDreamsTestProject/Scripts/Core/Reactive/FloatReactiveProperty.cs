using System;

namespace GardenOfDreamsTestProject.Scripts.Core.Reactive
{
    public sealed class FloatReactiveProperty : IReadOnlyReactiveProperty<float>
    {
        private float _value;
        private float _actualValue;
        private readonly float _minimumChangeStep;

        public float Value
        {
            get => _value;
            set
            {
                _actualValue = value;
                if (_value - _actualValue < _minimumChangeStep)
                    return;
                var oldValue = _value;
                _value = _actualValue;
                ValueChanged?.Invoke(oldValue, _value);
            }
        }

        public event Action<float, float> ValueChanged;
        
        public FloatReactiveProperty(float initialValue, float minimumChangeStep)
        {
            _value = initialValue;
            _minimumChangeStep = minimumChangeStep;
        }
    }
}