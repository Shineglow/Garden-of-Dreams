using System;
using System.Collections.Generic;
using System.Linq;
using GardenOfDreamsTestProject.Scripts.Configuration.Buildings;
using UnityEngine;
using UnityEngine.UI;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.UI.Building
{
    public class BuildingUIView : MonoBehaviour, IBuildingUIView
    {
        [SerializeField] private OutlineBehaviour outline;
        [SerializeField] private List<Button> buildingsButtons;
        [SerializeField] private Button buildButton;
        [SerializeField] private Button destroyButton;

        private Dictionary<Button, EBuildings> _buttonToBuildingType;

        public event Action<EBuildings> BuildingSelected;
        public event Action BuildButtonPressed;
        public event Action DestroyButtonPressed;

        public void SetSelectedBuilding(EBuildings building)
        {
            var button = _buttonToBuildingType.First(kvp => kvp.Value == building).Key;
            outline.MoveToSelected(button.gameObject);
            BuildingSelected?.Invoke(building);
        }

        private void Awake()
        {
            foreach (var buildingsButton in buildingsButtons)
            {
                buildingsButton.onClick.AddListener(() => OnBuildingButtonClicked(buildingsButton));
            }
            
            buildButton.onClick.AddListener(() => BuildButtonPressed?.Invoke());
            destroyButton.onClick.AddListener(() => DestroyButtonPressed?.Invoke());
        }

        public void Initialize(List<(EBuildings buildingType, Sprite sprite)> buildingsInfo, int firstSelected)
        {
            _buttonToBuildingType = new Dictionary<Button, EBuildings>();
            for (var i = 0; i < buildingsInfo.Count; i++)
            {
                _buttonToBuildingType.Add(buildingsButtons[i], buildingsInfo[i].buildingType);
                buildingsButtons[i].GetComponentsInChildren<Image>()[1].sprite =buildingsInfo[i].sprite;
            }

            outline.MoveToSelected(buildingsButtons[firstSelected].gameObject);
        }

        private void OnBuildingButtonClicked(Button buildingsButton)
        {
            outline.MoveToSelected(buildingsButton.gameObject);
            BuildingSelected?.Invoke(_buttonToBuildingType[buildingsButton]);
        }
    }
}