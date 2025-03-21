using GardenOfDreamsTestProject.Scripts.Core.Input;
using GardenOfDreamsTestProject.Scripts.Gameplay.Grid;

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
            _model.IsNeedToPlace.ValueChanged += TryPlace;
        }

        private void OnShadowModeChanged(bool oldValue, bool newValue)
        {
            _view.IsShadowModeEnabled = newValue;
        }

        private void TryPlace(bool oldValue, bool newValue)
        {
            if (_gridSystem.TryPlaceBuildingOnGrid(_model, _view))
            {
                
            }
        }

        private void TryDestroy(bool oldValue, bool newValue)
        {
            if (_gridSystem.TryDestroyBuilding(_model))
            {
                
            }
        }

        private void OnViewPointerDown()
        {
            var mousePosition = _inputSystem.GetMousePosition();
            // var _gridSystem.Mouse(mousePosition);
            
        }
    }
}