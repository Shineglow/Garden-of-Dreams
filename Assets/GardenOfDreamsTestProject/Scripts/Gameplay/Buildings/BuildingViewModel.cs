using GardenOfDreamsTestProject.Scripts.Core.Input;
using GardenOfDreamsTestProject.Scripts.Gameplay.Grid;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.Buildings
{
    public class BuildingViewModel : IBuildingViewModel
    {
        private readonly IBuildingModel _model;
        private readonly IBuildingView _view;
        private readonly IInputSystem _inputSystem;
        private readonly IGridSystem _gridSystem;

        public BuildingViewModel(IBuildingModel model, IBuildingView view)
        {
            _model = model;
            _view = view;
            _inputSystem = CompositionRoot.GetInputSystem();
            _gridSystem = CompositionRoot.GetGridSystem();
            
            _view.PointerDown += OnViewPointerDown;
            
            _model.IsNeedToDestroy.ValueChanged += TryDestroy;
            _model.IsShadowObject.ValueChanged += OnShadowModeChanged;
            _model.ShadowColor.ValueChanged += OnShadowColorChanged;
            _model.IsNeedToPlace.ValueChanged += TryPlace;
        }

        private void OnShadowColorChanged(Color oldValue, Color newValue)
        {
            if (_model.IsShadowObject.Value)
            {
                _view.SetColor(_model.ShadowColor.Value);
            }
        }

        private void OnShadowModeChanged(bool oldValue, bool newValue)
        {
            _view.IsShadowModeEnabled = newValue;
            if (newValue)
            {
                _view.SetColor(_model.ShadowColor.Value);
            }
            else
            {
                _view.SetColor(Color.white);
            }
        }

        private void TryPlace(bool oldValue, bool newValue)
        {
            
        }

        private void TryDestroy(bool oldValue, bool newValue)
        {
            
        }

        private void OnViewPointerDown()
        {
            var mousePosition = _inputSystem.GetMousePosition();
            // var _gridSystem.Mouse(mousePosition);
            
        }
    }
}