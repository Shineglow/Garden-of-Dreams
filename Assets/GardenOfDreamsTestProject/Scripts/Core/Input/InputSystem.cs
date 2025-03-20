using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Core.Input
{
    public class InputSystem : IInputSystem
    {
        private GameInput _gameInput;

        private bool _isActive;

        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (value == _isActive)
                    return;
                _isActive = value;
                if (value)
                {
                    OnEnable();
                }
                else
                {
                    OnDisable();
                }
            }
        }

        public InputSystem()
        {
            _gameInput = new GameInput();
            _gameInput.Enable();
        }

        public Vector2 GetMousePosition() => _gameInput.Default.MousePosition.ReadValue<Vector2>();

        private void OnEnable()
        {
            // 
        }
        
        private void OnDisable()
        {
            //
        }
    }
}