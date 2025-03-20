using System;

namespace GardenOfDreamsTestProject.Scripts.Core.Reactive
{
    public class BoolReactiveProperty : IReadOnlyReactiveProperty<bool>
    {
        private bool _value;
        private readonly bool _resetAfterSwitchValueWithoutActionCall;

        public bool Value
        {
            get => _value;
            set
            {
                if (_value == value) return;
                _value = value;
                ValueChanged?.Invoke(!_value, _value);
                if(_resetAfterSwitchValueWithoutActionCall)
                    _value = !_value;
            }
        }

        public event Action<bool, bool> ValueChanged;
        
        public BoolReactiveProperty(bool initialValue, bool resetAfterSwitchValueWithoutActionCall)
        {
            _value = initialValue;
            _resetAfterSwitchValueWithoutActionCall = resetAfterSwitchValueWithoutActionCall;
        }
    }
}