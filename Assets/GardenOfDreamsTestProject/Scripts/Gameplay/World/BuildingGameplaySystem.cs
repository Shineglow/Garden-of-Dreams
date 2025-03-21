using GardenOfDreamsTestProject.Scripts.Core.Camera;
using GardenOfDreamsTestProject.Scripts.Core.Input;
using GardenOfDreamsTestProject.Scripts.Gameplay.Buildings;
using GardenOfDreamsTestProject.Scripts.Gameplay.Factories.Buildings;
using GardenOfDreamsTestProject.Scripts.Gameplay.Grid;
using GardenOfDreamsTestProject.Scripts.Gameplay.UI.Building;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.World
{
    public class BuildingGameplaySystem : IBuildingGameplaySystem
    {
        private readonly IGridSystem _gridSystem;
        private readonly IBuildingUIModel _buildingUIModel;
        private readonly IBuildingsFactory _buildingFactory;
        private readonly ICameraSystem _cameraSystem;
        private readonly IInputSystem _inputSystem;
        private IBuildingModel _actualModel;

        public BuildingGameplaySystem(IGridSystem gridSystem, IBuildingUIModel buildingUIModel)
        {
            _gridSystem = gridSystem;
            _buildingUIModel = buildingUIModel;
            _cameraSystem = CompositionRoot.GetCameraSystem();
            _inputSystem = CompositionRoot.GetInputSystem();
            
            _buildingFactory = CompositionRoot.GetAllFactories().GetBuildingsFactory();
            buildingUIModel.BuildPressed.ValueChanged += OnBuildPressed;
            buildingUIModel.DestroyPressed.ValueChanged += OnDestroyPressed;
        }

        private void OnDestroyPressed(bool arg1, bool arg2)
        {
            throw new System.NotImplementedException();
        }

        private void OnBuildPressed(bool arg1, bool arg2)
        {
            _gridSystem.PointerMoveUnderGrid += OnPointerMoveUnderGrid;
            _inputSystem.LeftMouseDown += TryPlaceOnGrid;
            // создать здание с режимом тени,
            _actualModel = _buildingFactory.GetBuilding(_buildingUIModel.SelectedBuilding.Value);
            var screenCenterWorldPosition = _cameraSystem.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
            var gridPosition = _gridSystem.WorldToGridPosition(screenCenterWorldPosition);
            _actualModel.GridPosition.Value = gridPosition;
            // проверить пересечения с сеткой и другими объектами,
            // подписатся на делегаты кликов по сетке и движения курсора над сеткой
            // при движении двигать, при клике попытаться поставить
            // подсвечивать красным если нельзя, подсвечивать зелёным, если можно
        }

        private void TryPlaceOnGrid()
        {
            throw new System.NotImplementedException();
        }

        private void OnPointerMoveUnderGrid()
        {
            throw new System.NotImplementedException();
        }
    }
}
